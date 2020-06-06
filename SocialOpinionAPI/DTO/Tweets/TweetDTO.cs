using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Tweets
{

    [JsonObject("organic_metrics")]
    public class OrganicMetrics
    {
        [JsonProperty("impression_count")]
        public int impression_count { get; set; }

        [JsonProperty("like_count")]
        public int like_count { get; set; }

        [JsonProperty("reply_count")]
        public int reply_count { get; set; }

        [JsonProperty("retweet_count")]
        public int retweet_count { get; set; }
    }

    [JsonObject("public_metrics")]
    public class PublicMetrics
    {
        [JsonProperty("retweet_count")]
        public int retweet_count { get; set; }

        [JsonProperty("reply_count")]
        public int reply_count { get; set; }

        [JsonProperty("like_count")]
        public int like_count { get; set; }

        [JsonProperty("quote_count")]
        public int quote_count { get; set; }
    }

    public class Data
    {

        [JsonProperty("author_id")]
        public string author_id { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("possibly_sensitive")]
        public bool possibly_sensitive { get; set; }

        [JsonProperty("organic_metrics")]
        public OrganicMetrics organic_metrics { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics public_metrics { get; set; }

        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }

    public class Url
    {

        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("expanded_url")]
        public string expanded_url { get; set; }

        [JsonProperty("display_url")]
        public string display_url { get; set; }
    }

    public class Urls
    {

        [JsonProperty("urls")]
        public IList<Url> urls { get; set; }
    }

    public class Entities
    {

        [JsonProperty("url")]
        public Url url { get; set; }
    }

    public class User
    {

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("entities")]
        public Entities entities { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("pinned_tweet_id")]
        public string pinned_tweet_id { get; set; }

        [JsonProperty("profile_image_url")]
        public string profile_image_url { get; set; }

        [JsonProperty("protected")]
        public bool is_protected { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics public_metrics { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("verified")]
        public bool verified { get; set; }
    }

    public class Includes
    {

        [JsonProperty("users")]
        public IList<User> users { get; set; }
    }

    public class TweetDTO
    {

        [JsonProperty("data")]
        public Data data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }
    }

    public class TweetsDTO
    {

        [JsonProperty("data")]
        public IList<Data> data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }
    }

}

