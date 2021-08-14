using SocialOpinionAPI.Core;

namespace SocialOpinionAPI.Clients
{
    public class LikesClient
    {
        private string _liking_users = "https://api.twitter.com/2/tweets/:id/liking_users";
        private string _liked_tweets = "https://api.twitter.com/2/users/:id/liked_tweets";
        private string _like_tweet = "https://api.twitter.com/2/users/:id/likes";
        private string _unlike_tweet = "https://api.twitter.com/2/users/:id/likes/:tweet_id";

        private OAuthInfo _oAuthInfo;

        public LikesClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetLikingUsers(string tweetId, string expansions, string tweet_fields,
                                string media_fields, string place_fields, string poll_fields,
                                string user_fields)
        {
            string url = _liking_users.Replace(":id", tweetId);

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", url);

            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string GetUsersLikedTweets(string userid, string maxResults, string pagination_token, string expansions, string tweet_fields,
                                string media_fields, string place_fields, string poll_fields,
                                string user_fields)
        {
            string url = _liked_tweets.Replace(":id", userid);

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", url);

            if(!string.IsNullOrEmpty(maxResults))
            {
                rb.AddParameter("max_results", maxResults);
            }
            
            if(!string.IsNullOrEmpty(pagination_token))
            {
                rb.AddParameter("pagination_token", pagination_token);
            }

            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("media.fields", media_fields);
            rb.AddParameter("place.fields", place_fields);
            rb.AddParameter("poll.fields", poll_fields);
            rb.AddParameter("user.fields", user_fields);

            return rb.Execute();
        }

        public string LikeTweet(string userId, string jsonBody)
        {
            string url = _like_tweet.Replace(":id", userId);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "POST", url);
            return rb.ExecuteJsonParamsInBody(jsonBody);
        }

        public string UnLikeTweet(string userId, string tweetId)
        {
            string url = _unlike_tweet.Replace(":id", userId);
            url = url.Replace(":tweet_id", tweetId);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "DELETE", url);
            return rb.Execute();
        }

    }
}
