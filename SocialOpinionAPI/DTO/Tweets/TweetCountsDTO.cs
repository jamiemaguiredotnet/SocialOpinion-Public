using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SocialOpinionAPI.DTO.Tweets
{
    public class TweetCountData
    {

        [JsonProperty("end")]
        public DateTime end { get; set; }

        [JsonProperty("start")]
        public DateTime start { get; set; }

        [JsonProperty("tweet_count")]
        public int tweet_count { get; set; }
    }

    public class Meta
    {

        [JsonProperty("total_tweet_count")]
        public int total_tweet_count { get; set; }
    }

    public class TweetCountsDTO
    {

        [JsonProperty("data")]
        public IList<TweetCountData> data { get; set; }

        [JsonProperty("meta")]
        public Meta meta { get; set; }
    }


}
