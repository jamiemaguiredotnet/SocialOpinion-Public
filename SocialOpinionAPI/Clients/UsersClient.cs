using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class UsersClient
    {
        private string _singleUserEndpoint = "https://api.twitter.com/2/users/by/username/";
        private string _multipleUsersEndpoint = "https://api.twitter.com/2/users/by";

        private OAuthInfo _oAuthInfo;

        public UsersClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetSingleUser(string username, string expansions, string tweet_fields, string media_fields,
                                    string poll_fields, string place_fields, string user_fields)
        {
            if (!string.IsNullOrEmpty(_oAuthInfo.AccessSecret) && !string.IsNullOrEmpty(_oAuthInfo.AccessSecret))
            {
                // OAuth1 - user scoped
                RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _singleUserEndpoint + username);

                rb.AddParameter("expansions", expansions);
                rb.AddParameter("tweet.fields", tweet_fields);
                rb.AddParameter("user.fields", user_fields);

                return rb.Execute();
            }
            else
            {
                // bearer token - application scoped
                BearerTokenRequestBuilder rb = new BearerTokenRequestBuilder(_oAuthInfo, "GET", _singleUserEndpoint + username);
                rb.AddParameter("expansions", expansions);
                rb.AddParameter("tweet.fields", tweet_fields);
                rb.AddParameter("user.fields", user_fields);

                return rb.Execute();
            }
        }

        public string GetUsers(List<string> usernames, string expansions, string tweet_fields, string media_fields,
                                    string poll_fields, string place_fields, string user_fields)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _multipleUsersEndpoint);

            rb.AddParameter("expansions", expansions);
            rb.AddParameter("tweet.fields", tweet_fields);
            rb.AddParameter("user.fields", user_fields);
            rb.AddParameter("usernames", string.Join(",", usernames));

            string result = rb.Execute();

            return result;
        }


    }
}
