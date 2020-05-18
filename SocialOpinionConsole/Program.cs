using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.RecentSearch;
using SocialOpinionAPI.Models.FilteredStream;
using SocialOpinionAPI.Models.RecentSearch;
using SocialOpinionAPI.Models.TweetMetrics;
using SocialOpinionAPI.Models.Tweets;
using SocialOpinionAPI.Models.Users;
using SocialOpinionAPI.Services;
using SocialOpinionAPI.Services.FilteredStream;
using SocialOpinionAPI.Services.RecentSearch;
using SocialOpinionAPI.Services.Tweet;
using SocialOpinionAPI.Services.TweetMetrics;
using SocialOpinionAPI.Services.Users;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SocialOpinionConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string _ConsumerKey = ConfigurationManager.AppSettings.Get("ConsumerKey");
            string _ConsumerSecret = ConfigurationManager.AppSettings.Get("ConsumerSecret");
            string _AccessToken = ConfigurationManager.AppSettings.Get("AccessToken");
            string _AccessTokenSecret = ConfigurationManager.AppSettings.Get("AccessTokenSecret");

            OAuthInfo oAuthInfo = new OAuthInfo
            {
                AccessSecret = _AccessTokenSecret,
                AccessToken = _AccessToken,
                ConsumerSecret = _ConsumerSecret,
                ConsumerKey = _ConsumerKey
            };

            // Recent Search 
            RecentSearchService searchService = new RecentSearchService(oAuthInfo);
            
            List<RecentSearchResultsModel> resultsModels = searchService.SearchTweets("iphone", 100);

            // Tweet(s)
            TweetService tweetsService = new TweetService(oAuthInfo);
            TweetModel tweetModel = tweetsService.GetTweet("1258736674844094465");

            List<string> tids = new List<string>();
            tids.Add("1258736674844094465"); // social opinion tweet
            tids.Add("1199807993942020098"); // social opinion tweet
            TweetsModel tweetModels = tweetsService.GetTweets(tids);

            // User(s)
            UserService userService = new UserService(oAuthInfo);
            UserModel userModel = userService.GetUser("jamie_maguire1");

            List<string> users = new List<string>();
            users.Add("jamie_maguire1");
            users.Add("socialopinions");
            UsersModel usersResults = userService.GetUsers(users);
            
            // Metrics  
            List<string> ids = new List<string>();
            ids.Add("1258736674844094465"); // social opinion tweet
            TweetMetricsService service = new TweetMetricsService(oAuthInfo);
            List<TweetMetricModel> metricModels = service.GetTweetMetrics(ids);

            // testing Filtered Stream
            FilteredStreamService filteredStreamService = new FilteredStreamService(oAuthInfo);

            List<FilteredStreamRule> rules = filteredStreamService.CreateRule(
                new MatchingRule { tag = "testing #iPhone", Value = "#iphone" });
           
            filteredStreamService.DataReceivedEvent += FilteredStreamService_DataReceivedEvent;
            filteredStreamService.StartStream("https://api.twitter.com/labs/1/tweets/stream/filter?tweet.format=detailed", 10, 5);
        }

        private static void FilteredStreamService_DataReceivedEvent(object sender, EventArgs e)
        {
            FilteredStreamService.DataReceivedEventArgs eventArgs = e as FilteredStreamService.DataReceivedEventArgs;
            FilteredStreamModel model = eventArgs.FilteredStreamDataResponse;
        }
    }
}
