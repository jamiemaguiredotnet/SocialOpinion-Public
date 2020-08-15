using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class TweetsClient
    {

        private string _tweetEndpoint = "https://api.twitter.com/2/tweets/";
        private string _tweetsEndpoint = "https://api.twitter.com/2/tweets";

        private OAuthInfo _oAuthInfo;

        public TweetsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweet(string id, string expansions, string tweet_fields, string media_fields,
                               string poll_fields, string place_fields, string user_fields)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _tweetEndpoint + id);

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
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _tweetsEndpoint);

            rb.AddParameter("ids", string.Join(",", ids));
            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }
    }
}
