using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Timeline
{
    public class OrganicMetrics
    {

        [JsonProperty("impression_count")]
        public int impression_count { get; set; }

        [JsonProperty("reply_count")]
        public int reply_count { get; set; }

        [JsonProperty("user_profile_clicks")]
        public int user_profile_clicks { get; set; }

        [JsonProperty("retweet_count")]
        public int retweet_count { get; set; }

        [JsonProperty("like_count")]
        public int like_count { get; set; }

        [JsonProperty("url_link_clicks")]
        public int? url_link_clicks { get; set; }
    }

    public class NonPublicMetrics
    {

        [JsonProperty("user_profile_clicks")]
        public int user_profile_clicks { get; set; }

        [JsonProperty("impression_count")]
        public int impression_count { get; set; }

        [JsonProperty("url_link_clicks")]
        public int? url_link_clicks { get; set; }
    }

    public class TweetPublicMetrics
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

    public class TweetDatum
    {

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("organic_metrics")]
        public OrganicMetrics organic_metrics { get; set; }

        [JsonProperty("possibly_sensitive")]
        public bool possibly_sensitive { get; set; }

        [JsonProperty("non_public_metrics")]
        public NonPublicMetrics non_public_metrics { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("conversation_id")]
        public string conversation_id { get; set; }

        [JsonProperty("public_metrics")]
        public TweetPublicMetrics public_metrics { get; set; }

        [JsonProperty("text")]
        public string text { get; set; }

        [JsonProperty("reply_settings")]
        public string reply_settings { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("author_id")]
        public string author_id { get; set; }

        [JsonProperty("entities")]
        public Entities entities { get; set; }

        [JsonProperty("attachments")]
        public Attachments attachments { get; set; }

        [JsonProperty("context_annotations")]
        public IList<ContextAnnotation> context_annotations { get; set; }

        [JsonProperty("in_reply_to_user_id")]
        public string in_reply_to_user_id { get; set; }

        [JsonProperty("referenced_tweets")]
        public IList<ReferencedTweet> referenced_tweets { get; set; }
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

    public class TweetMeta
    {

        [JsonProperty("oldest_id")]
        public string oldest_id { get; set; }

        [JsonProperty("newest_id")]
        public string newest_id { get; set; }

        [JsonProperty("result_count")]
        public int result_count { get; set; }

        [JsonProperty("next_token")]
        public string next_token { get; set; }
    }

    public class UserTweetTimelineDTO
    {

        [JsonProperty("data")]
        public IList<TweetDatum> data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }

        [JsonProperty("errors")]
        public IList<Error> errors { get; set; }

        [JsonProperty("meta")]
        public TweetMeta meta { get; set; }
    }





}
