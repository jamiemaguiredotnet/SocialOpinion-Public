using SocialOpinionAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Labs
{
    public class MetricsClient
    {
        private OAuthInfo _oAuthInfo;

        public MetricsClient(OAuthInfo oAuthInfo)
        {
            _oAuthInfo = oAuthInfo;
        }

        public string GetTweetMetrics(List<string> tweetIds)
        {
            //e.g. https://api.twitter.com/labs/1/tweets/metrics/private?ids=1167028477675130880

            RequestBuilder rb = new RequestBuilder(_oAuthInfo, "GET", "https://api.twitter.com/labs/1/tweets/metrics/private");

            rb.AddParameter("ids", string.Join(",", tweetIds));

            string result = rb.Execute();

            return result;
        }
    }
}
