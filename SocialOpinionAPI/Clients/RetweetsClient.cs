using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class RetweetsClient
    {
        private string _deleteRetweet = "https://api.twitter.com/2/users/:id/retweets/:source_tweet_id";
        private string _getWhoRetweeted = "https://api.twitter.com/2/tweets/:id/retweeted_by";
        private string _postRetweet = "https://api.twitter.com/2/users/:id/retweets";

        private OAuthInfo _oAuthInfo;

        public RetweetsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string Retweet(string id, string jsonBody)
        {
            string url = _postRetweet.Replace(":id", id);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "POST", url);
            return rb.ExecuteJsonParamsInBody(jsonBody);
        }

        public string RemoveRetweet(string id, string tweetIdToRemoveRT)
        {
            string url = _deleteRetweet.Replace(":source_tweet_id", tweetIdToRemoveRT);
            url = url.Replace(":id", id);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "DELETE", url);
            return rb.Execute();
        }

        public string GetWhoRetweetedTweet(string id, string expansions, string tweet_fields, string media_fields,
                                    string poll_fields, string place_fields, string user_fields)
        {
            string url = _getWhoRetweeted.Replace(":id", id);
            url = url.Replace(":id", _getWhoRetweeted);

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", url);

            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }


    }
}
