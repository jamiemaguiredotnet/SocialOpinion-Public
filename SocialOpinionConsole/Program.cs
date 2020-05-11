using SocialOpinionAPI.Clients;
using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.RecentSearch;
using SocialOpinionAPI.Models.FilteredStream;
using SocialOpinionAPI.Models.RecentSearch;
using SocialOpinionAPI.Models.TweetMetrics;
using SocialOpinionAPI.Services.FilteredStream;
using SocialOpinionAPI.Services.RecentSearch;
using SocialOpinionAPI.Services.TweetMetrics;
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

            // testing Recent Search 
            RecentSearchService searchService = new RecentSearchService(oAuthInfo);
            List<RecentSearchResultsModel> resultsModels = searchService.SearchTweets("iphone", 100);

            // testing Metrics with 
            List<string> ids = new List<string>();
            ids.Add("1258626243987230722");
            TweetMetricsService service = new TweetMetricsService(oAuthInfo);
            List<TweetMetricModel> metricModels = service.GetTweetMetrics(ids);

            // testing Filtered Stream
            FilteredStreamService filteredStreamService = new FilteredStreamService(oAuthInfo);
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
