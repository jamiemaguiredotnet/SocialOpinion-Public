using SocialOpinionAPI.Core;
using SocialOpinionAPI.DTO.HideReplies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class HideRepliesClient
    {
        private string _hideReply = "https://api.twitter.com/2/tweets/:id/hidden";
        private OAuthInfo _oAuthInfo;

        public HideRepliesClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string HideReply(string tweetId,string jsonBody)
        {
            string url = _hideReply.Replace(":id", tweetId);
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "PUT", url);
            return rb.ExecuteJsonParamsInBody(jsonBody);
        }
    }
}
