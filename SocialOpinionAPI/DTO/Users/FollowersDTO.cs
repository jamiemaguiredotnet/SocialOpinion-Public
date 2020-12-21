using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Users.Followers
{

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

    public class Mention
    {

        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }
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

    public class Description
    {

        [JsonProperty("mentions")]
        public IList<Mention> mentions { get; set; }

        [JsonProperty("hashtags")]
        public IList<Hashtag> hashtags { get; set; }

        [JsonProperty("urls")]
        public IList<Url> urls { get; set; }
    }

    public class Entities
    {

        [JsonProperty("url")]
        public Url url { get; set; }

        [JsonProperty("description")]
        public Description description { get; set; }
    }

    public class Datum
    {

        [JsonProperty("public_metrics")]
        public PublicMetrics public_metrics { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("profile_image_url")]
        public string profile_image_url { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("entities")]
        public Entities entities { get; set; }

        [JsonProperty("pinned_tweet_id")]
        public string pinned_tweet_id { get; set; }

        [JsonProperty("verified")]
        public bool verified { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("protected")]
        public bool is_protected { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }
    }

    public class Error
    {

        [JsonProperty("resource_type")]
        public string resource_type { get; set; }

        [JsonProperty("field")]
        public string field { get; set; }

        [JsonProperty("parameter")]
        public string parameter { get; set; }

        [JsonProperty("value")]
        public string value { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("section")]
        public string section { get; set; }

        [JsonProperty("detail")]
        public string detail { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    }

    public class Meta
    {

        [JsonProperty("result_count")]
        public int result_count { get; set; }

        [JsonProperty("next_token")]
        public string next_token { get; set; }
    }

    public class FollowersDTO
    {

        [JsonProperty("data")]
        public IList<Datum> data { get; set; }

        [JsonProperty("errors")]
        public IList<Error> errors { get; set; }

        [JsonProperty("meta")]
        public Meta meta { get; set; }
    }



}
