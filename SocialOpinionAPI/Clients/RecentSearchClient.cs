using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SocialOpinionAPI.Clients
{
    public class RecentSearchClient
    {
        private const int _defaultTweetsPerPage = 100;
        private string _recentSearchEndpoint = "https://api.twitter.com/2/tweets/search/recent";
        private OAuthInfo _oAuthInfo;

        public RecentSearchClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweets(string query, string start_time, string end_time,
                                string since_id, string until_id, int max_results,
                                string next_token, string expansions, string tweet_fields,
                                string media_fields, string place_fields, string poll_fields,
                                string user_fields)
        {
            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", _recentSearchEndpoint);

            rb.AddParameter("query", query);
            if (start_time != string.Empty) { rb.AddParameter("start_time", start_time); }
            if (end_time != string.Empty) { rb.AddParameter("end_time", end_time); }
            if (since_id != string.Empty) { rb.AddParameter("since_id", since_id); }
            if (until_id != string.Empty) { rb.AddParameter("until_id", until_id); }
            rb.AddParameter("max_results", max_results.ToString());
            if(next_token!=string.Empty) { rb.AddParameter("next_token", next_token); }
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            string result = rb.Execute();

            return result;
        }
    }
}
