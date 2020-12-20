using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.RecentSearch
{
    public class Attachments
    {
        [JsonProperty("media_keys")]
        public IList<string> media_keys { get; set; }
    }

    public class Domain
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
    }

    public class Entity
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
    }

    public class ContextAnnotation
    {

        [JsonProperty("domain")]
        public Domain domain { get; set; }

        [JsonProperty("entity")]
        public Entity entity { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }

        [JsonProperty("height")]
        public int height { get; set; }
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

        [JsonProperty("images")]
        public IList<Image> images { get; set; }

        [JsonProperty("status")]
        public int? status { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("unwound_url")]
        public string unwound_url { get; set; }
    }

    public class Annotation
    {
        [JsonProperty("start")]
        public int start { get; set; }

        [JsonProperty("end")]
        public int end { get; set; }

        [JsonProperty("probability")]
        public double probability { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("normalized_text")]
        public string normalized_text { get; set; }
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

    public class Entities
    {
        [JsonProperty("urls")]
        public IList<Url> urls { get; set; }

        [JsonProperty("annotations")]
        public IList<Annotation> annotations { get; set; }

        [JsonProperty("mentions")]
        public IList<Mention> mentions { get; set; }

        [JsonProperty("hashtags")]
        public IList<Hashtag> hashtags { get; set; }
    }

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

    public class UserPublicMetrics
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

    public class ReferencedTweet
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }

    public class Datum
    {
        [JsonProperty("attachments")]
        public Attachments attachments { get; set; }

        [JsonProperty("author_id")]
        public string author_id { get; set; }

        [JsonProperty("context_annotations")]
        public IList<ContextAnnotation> context_annotations { get; set; }

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

        [JsonProperty("referenced_tweets")]
        public IList<ReferencedTweet> referenced_tweets { get; set; }

        [JsonProperty("in_reply_to_user_id")]
        public string in_reply_to_user_id { get; set; }
    }

    public class Medium
    {
        [JsonProperty("height")]
        public int height { get; set; }

        [JsonProperty("media_key")]
        public string media_key { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("width")]
        public int width { get; set; }
    }

    public class User
    {
        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("profile_image_url")]
        public string profile_image_url { get; set; }

        [JsonProperty("protected")]
        public bool is_protected { get; set; }

        [JsonProperty("public_metrics")]
        public SocialOpinionAPI.Models.Users.PublicMetrics public_metrics { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("verified")]
        public bool verified { get; set; }

        [JsonProperty("entities")]
        public Entities entities { get; set; }

        [JsonProperty("pinned_tweet_id")]
        public string pinned_tweet_id { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }
    }

    public class Tweet
    {
        [JsonProperty("attachments")]
        public Attachments attachments { get; set; }

        [JsonProperty("author_id")]
        public string author_id { get; set; }

        [JsonProperty("context_annotations")]
        public IList<ContextAnnotation> context_annotations { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("entities")]
        public Entity entities { get; set; }

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

        [JsonProperty("in_reply_to_user_id")]
        public string in_reply_to_user_id { get; set; }

        [JsonProperty("referenced_tweets")]
        public IList<ReferencedTweet> referenced_tweets { get; set; }
    }

    public class Includes
    {
        [JsonProperty("media")]
        public IList<Medium> media { get; set; }

        [JsonProperty("users")]
        public IList<User> users { get; set; }

        [JsonProperty("tweets")]
        public IList<Tweet> tweets { get; set; }
    }

    public class Meta
    {
        [JsonProperty("newest_id")]
        public string newest_id { get; set; }

        [JsonProperty("oldest_id")]
        public string oldest_id { get; set; }

        [JsonProperty("result_count")]
        public int result_count { get; set; }

        [JsonProperty("next_token")]
        public string next_token { get; set; }
    }

    public class RecentSearchResultsDTO
    {
        [JsonProperty("data")]
        public IList<Datum> data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }

        [JsonProperty("meta")]
        public Meta meta { get; set; }
    }
}