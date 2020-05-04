using SocialOpinionAPI.Core.Labs.FilteredStream.Logic;
using SocialOpinionAPI.Labs;
using System;
using System.Collections.Generic;

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
            string _ConsumerKey = "";
            string _ConsumerSecret = "";
            string _AccessToken = "";
            string _AccessTokenSecret = "";
            
            MetricsClient metricsClient = new MetricsClient(new SocialOpinionAPI.Core.OAuthInfo
            {
                AccessSecret = _AccessTokenSecret,
                AccessToken = _AccessToken,
                ConsumerSecret = _ConsumerSecret,
                ConsumerKey = _ConsumerKey
            });

            List<string> ids = new List<string>();
            ids.Add("1256813051623411712");

            metricsClient.GetTweetMetrics(ids);
            

            FilteredStreamClient filteredStreamClient =
                new FilteredStreamClient("", "");

            filteredStreamClient.FilteredStreamDataReceivedEvent += FilteredStreamClient_FilteredStreamDataReceivedEvent;
            filteredStreamClient
                .StartStream("https://api.twitter.com/labs/1/tweets/stream/filter?tweet.format=detailed", 10, 5);
        }
    }
}
