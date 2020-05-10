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
        private static void FilteredStreamClient_FilteredStreamDataReceivedEvent(object sender, EventArgs e)
        {
            FilteredStreamClient.TweetReceivedEventArgs eventArgs = e as FilteredStreamClient.TweetReceivedEventArgs;

            string dataResponse = eventArgs.filteredStreamDataResponse;
            Console.WriteLine(dataResponse);
        }

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
   
            //RecentSearchService searchService = new RecentSearchService(oAuthInfo);
            //List<RecentSearchResultsModel> resultsModels = searchService.SearchTweets("iphone", 100);

            // testing Metrics API with strongly typed objects and new Service class
            // that encapsulates low-level mapping from the Labs API
            //List<string> ids = new List<string>();
            //ids.Add("1258626243987230722");
            //TweetMetricsService service = new TweetMetricsService(oAuthInfo);
            //List<TweetMetricModel> metricModels = service.GetTweetMetrics(ids);

            FilteredStreamService filteredStreamService = new FilteredStreamService(oAuthInfo);
            filteredStreamService.DataReceivedEvent += FilteredStreamService_DataReceivedEvent;
            filteredStreamService.StartStream("https://api.twitter.com/labs/1/tweets/stream/filter?tweet.format=detailed", 10, 5);       
          }

        private static void FilteredStreamService_DataReceivedEvent(object sender, EventArgs e)
        {
            //
            //throw new NotImplementedException();
            FilteredStreamService.DataReceivedEventArgs eventArgs = e as FilteredStreamService.DataReceivedEventArgs;
            FilteredStreamModel model = eventArgs.FilteredStreamDataResponse;
        }
    }
}
