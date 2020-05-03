using SocialOpinionAPI.Core.Labs.FilteredStream.Logic;
using System;

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
            FilteredStreamClient filteredStreamClient =
                new FilteredStreamClient("", "");

            filteredStreamClient.FilteredStreamDataReceivedEvent += FilteredStreamClient_FilteredStreamDataReceivedEvent;
            filteredStreamClient
                .StartStream("https://api.twitter.com/labs/1/tweets/stream/filter?tweet.format=detailed", 10, 5);
        }
    }
}
