using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class BookmarkClient
    {
        private string _bookmarks = "https://api.twitter.com/2/users/:id/bookmarks";
        private string _blockingDelete = "https://api.twitter.com/2/users/:source_user_id/blocking/:target_user_id";

        private OAuthInfo _oAuthInfo;

        public BookmarkClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }


        public string GetBookmarks(string userid, string expansions, int max_results, string pagination_token, string tweet_fields, string user_fields)
        {
            string url = _bookmarks.Replace(":id", userid);

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", url);

            if (!string.IsNullOrEmpty(expansions))
            {
                rb.AddParameter("expansions", expansions);
            }

            if (!string.IsNullOrEmpty(max_results.ToString()))
            {
                rb.AddParameter("max_results", max_results.ToString());
            }

            if (!string.IsNullOrEmpty(pagination_token))
            {
                rb.AddParameter("pagination_token", pagination_token);
            }

            if (!string.IsNullOrEmpty(tweet_fields))
            {
                rb.AddParameter("tweet.fields", tweet_fields);
            }

            if (!string.IsNullOrEmpty(user_fields))
            {
                rb.AddParameter("user.fields", user_fields);
            }

            return rb.Execute();
        }
    }
}
