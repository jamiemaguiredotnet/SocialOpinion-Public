using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Users
{
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

    public class Hashtag
    {

        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("tag")]
        public string tag { get; set; }
    }

    public class Mention
    {

        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }
    }

    public class Description
    {

        [JsonProperty("hashtags")]
        public IList<Hashtag> hashtags { get; set; }

        [JsonProperty("mentions")]
        public IList<Mention> mentions { get; set; }
    }

    public class Entities
    {

        [JsonProperty("url")]
        public Url url { get; set; }

        [JsonProperty("description")]
        public Description description { get; set; }
    }

    public class PublicMetrics
    {

        [JsonProperty("followers_count")]
        public int followers_count { get; set; }

        [JsonProperty("following_count")]
        public int following_count { get; set; }

        [JsonProperty("tweet_count")]
        public int tweet_count { get; set; }

        [JsonProperty("listed_count")]
        public int listed_count { get; set; }
    }

    public class Data
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

    public class Attachments
    {

        [JsonProperty("media_keys")]
        public IList<string> media_keys { get; set; }
    }

    public class Tweet
    {

        [JsonProperty("attachments")]
        public Attachments attachments { get; set; }

        [JsonProperty("author_id")]
        public string author_id { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("entities")]
        public Entities entities { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("possibly_sensitive")]
        public bool possibly_sensitive { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics public_metrics { get; set; }

        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }
    }

    public class Includes
    {

        [JsonProperty("tweets")]
        public IList<Tweet> tweets { get; set; }
    }

    public class UserDTO
    {
        [JsonProperty("data")]
        public Data data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }
    }

    public class UsersDTO
    {
        [JsonProperty("data")]
        public IList<Data> data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }
    }


}



