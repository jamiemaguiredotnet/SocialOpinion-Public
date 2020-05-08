using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.TweetMetrics
{
    public class TweetMetricModel
    {
        public string tweet_id { get; set; }
        public int like_count { get; set; }
        public int retweet_count { get; set; }
        public int quote_count { get; set; }
        public int reply_count { get; set; }
        public int impression_count { get; set; }
    }
}
