using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Clients
{
    public class TweetsClient
    {
        
        private string _tweetsEndpoint = "https://api.twitter.com/labs/2/tweets/"
        private OAuthInfo _oAuthInfo;

        public TweetsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }



    }
}
