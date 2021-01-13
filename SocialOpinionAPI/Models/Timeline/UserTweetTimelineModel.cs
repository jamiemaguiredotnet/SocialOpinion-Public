using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Timeline
{
    public class OrganicMetrics
    {
        public int impression_count { get; set; }
        public int reply_count { get; set; }
        public int user_profile_clicks { get; set; }
        public int retweet_count { get; set; }
        public int like_count { get; set; }
        public int? url_link_clicks { get; set; }
    }

    public class TweetNonPublicMetrics
    {
        public int user_profile_clicks { get; set; }
        public int impression_count { get; set; }
        public int? url_link_clicks { get; set; }
    }

    public class TweetPublicMetrics
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }

    public class Domain
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Entity
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ContextAnnotation
    {
        public Domain domain { get; set; }
        public Entity entity { get; set; }
    }

    public class TweetDatum
    {
        public DateTime created_at { get; set; }
        public OrganicMetrics organic_metrics { get; set; }
        public bool possibly_sensitive { get; set; }
        public TweetNonPublicMetrics non_public_metrics { get; set; }
        public string id { get; set; }
        public string source { get; set; }
        public string conversation_id { get; set; }
        public TweetPublicMetrics public_metrics { get; set; }
        public string text { get; set; }
        public string reply_settings { get; set; }
        public string lang { get; set; }
        public string author_id { get; set; }
        public Entities entities { get; set; }
        public Attachments attachments { get; set; }
        public IList<ContextAnnotation> context_annotations { get; set; }
        public string in_reply_to_user_id { get; set; }
        public IList<ReferencedTweet> referenced_tweets { get; set; }
    }


    public class Error
    {
        public string resource_type { get; set; }
        public string field { get; set; }
        public string parameter { get; set; }
        public string value { get; set; }
        public string title { get; set; }
        public string section { get; set; }
        public string detail { get; set; }
        public string type { get; set; }
    }

    public class TweetMeta
    {
        public string oldest_id { get; set; }
        public string newest_id { get; set; }
        public int result_count { get; set; }
        public string next_token { get; set; }
    }

    public class UserTweetTimelineModel
    {
        public IList<TweetDatum> data { get; set; }
        public Includes includes { get; set; }
        public IList<Error> errors { get; set; }
        public TweetMeta meta { get; set; }
    }

}
