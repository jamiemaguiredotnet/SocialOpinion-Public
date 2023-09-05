using SocialOpinionAPI.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SocialOpinionAPI.Clients
{
    public class TweetsClient
    {
        private const string TweetEndpointV2 = "https://api.twitter.com/2/tweets/";
        private const string TweetsEndpoint = "https://api.twitter.com/2/tweets";
        private const string TweetCounts = "https://api.twitter.com/2/tweets/counts/recent";

        private readonly OAuthInfo _oAuthInfo;

        public TweetsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweet(string id, string expansions, string tweet_fields, string media_fields,
            string poll_fields, string place_fields, string user_fields)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", TweetEndpointV2 + id);

            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string GetTweets(List<string> ids, string expansions, string tweet_fields, string media_fields,
                              string poll_fields, string place_fields, string user_fields)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", TweetsEndpoint);

            rb.AddParameter("ids", string.Join(",", ids));
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string CountsRecent(string query, string end_time, string granularity, string since_id,
            string start_time, string until_id)
        {
            BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", TweetCounts);

            rb.AddParameter("query", query);

            if (!string.IsNullOrEmpty(end_time))
            {
                rb.AddParameter("end_time", end_time);
            }

            rb.AddParameter("granularity", granularity.ToLower());

            if (!string.IsNullOrEmpty(since_id))
            {
                rb.AddParameter("since_id", since_id);
            }

            if (!string.IsNullOrEmpty(start_time))
            {
                rb.AddParameter("start_time", start_time);
            }

            if (!string.IsNullOrEmpty(until_id))
            {
                rb.AddParameter("until_id", until_id);
            }

            return rb.Execute();
        }

        public string PostTweet(string text)
        {
            var rb = new RequestBuilder(_oAuthInfo, "POST", TweetsEndpoint);

            var json = JsonConvert.SerializeObject(new { text });
            
            var result = rb.ExecuteJsonParamsInBody(json);
            
            return result;
        }
    }
}