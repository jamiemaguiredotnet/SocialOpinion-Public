using System;
using System.Collections.Generic;

namespace SocialOpinionAPI.Models.Likes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Annotation
    {
        public int start { get; set; }
        public int end { get; set; }
        public double probability { get; set; }
        public string type { get; set; }
        public string normalized_text { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Entities
    {
        public List<Annotation> annotations { get; set; }
        public List<Url> urls { get; set; }
        public List<Hashtag> hashtags { get; set; }
        public Url url { get; set; }
        public Description description { get; set; }
    }

    public class ReferencedTweet
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class PublicMetrics
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
        public int followers_count { get; set; }
        public int following_count { get; set; }
        public int tweet_count { get; set; }
        public int listed_count { get; set; }
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
    }

    public class ContextAnnotation
    {
        public Domain domain { get; set; }
        public Entity entity { get; set; }
    }

    public class Datum
    {
        public Entities entities { get; set; }
        public string in_reply_to_user_id { get; set; }
        public string reply_settings { get; set; }
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string text { get; set; }
        public string conversation_id { get; set; }
        public string source { get; set; }
        public string lang { get; set; }
        public string author_id { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public bool possibly_sensitive { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public List<ContextAnnotation> context_annotations { get; set; }
    }

    public class Urls
    {
        public List<Url> urls { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
    }

    public class Description
    {
        public List<Url> urls { get; set; }
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
    }

    public class User
    {
        public string name { get; set; }
        public bool verified { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string id { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string url { get; set; }
        public string location { get; set; }
        public string username { get; set; }
        public bool @protected { get; set; }
        public Entities entities { get; set; }
        public string profile_image_url { get; set; }
        public string pinned_tweet_id { get; set; }
    }

    public class Tweet
    {
        public string reply_settings { get; set; }
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string text { get; set; }
        public string conversation_id { get; set; }
        public string source { get; set; }
        public Entities entities { get; set; }
        public string lang { get; set; }
        public string author_id { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public bool possibly_sensitive { get; set; }
        public PublicMetrics public_metrics { get; set; }
    }

    public class Includes
    {
        public List<User> users { get; set; }
        public List<Tweet> tweets { get; set; }
    }

    public class Meta
    {
        public int result_count { get; set; }
        public string next_token { get; set; }
    }

    public class LikesModel
    {
        public List<Datum> data { get; set; }
        public Includes includes { get; set; }
        public Meta meta { get; set; }
    }
}