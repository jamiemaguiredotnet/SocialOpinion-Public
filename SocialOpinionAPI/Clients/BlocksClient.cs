using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{ 
    public class BlocksClient
    {
        private string _blocking = "https://api.twitter.com/2/users/:id/blocking";
        private string _blockingDelete = "https://api.twitter.com/2/users/:source_user_id/blocking/:target_user_id";

        private OAuthInfo _oAuthInfo;

        public BlocksClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }


        public string GetBlocks(string userid, string expansions, int max_results, string pagination_token,string tweet_fields, string user_fields)
        {
            string url = _blocking.Replace(":id", userid);

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

        public string Block(string id, string jsonBody)
        {
            string url = _blocking.Replace(":id", id);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "POST", url);
            return rb.ExecuteJsonParamsInBody(jsonBody);
        }

        public string UnBlock(string id, string idToBlock)
        {
            string url = _blockingDelete.Replace(":source_user_id", id);
            url = url.Replace(":target_user_id", idToBlock);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "DELETE", url);
            return rb.Execute();
        }

    }
}
