﻿using SocialOpinionAPI.Core;
using System.Collections.Generic;

namespace SocialOpinionAPI.Clients
{
    public class MetricsClient
    {
        private string _privateEndpoint = "https://api.twitter.com/labs/1/tweets/metrics/private";
        private OAuthInfo _oAuthInfo;

        public MetricsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweetMetrics(List<string> tweetIds)
        {
            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", _privateEndpoint);

            rb.AddParameter("ids", string.Join(",", tweetIds));

            string result = rb.Execute();

            return result;
        }

    }
}
