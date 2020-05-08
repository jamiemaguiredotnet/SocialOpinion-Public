using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.TweetMetrics
{

    public class TweetMetricDTO
    {
        [JsonProperty("data")]
        public IList<Data> data { get; set; }
    }

    public class Tweet
    {
        [JsonProperty("like_count")]
        public int like_count { get; set; }

        [JsonProperty("retweet_count")]
        public int retweet_count { get; set; }

        [JsonProperty("quote_count")]
        public int quote_count { get; set; }

        [JsonProperty("reply_count")]
        public int reply_count { get; set; }

        [JsonProperty("impression_count")]
        public int impression_count { get; set; }
    }

    public class Data
    {
        [JsonProperty("tweet_id")]
        public string tweet_id { get; set; }

        [JsonProperty("tweet")]
        public Tweet tweet { get; set; }
    }

}
