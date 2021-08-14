using System;
using System.Collections.Generic;

namespace SocialOpinionAPI.Models.Blocks
{
    public class PublicMetrics
    {
        public int followers_count { get; set; }
        public int following_count { get; set; }
        public int tweet_count { get; set; }
        public int listed_count { get; set; }
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public List<Image> images { get; set; }
        public int? status { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string unwound_url { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
        public string id { get; set; }
    }

    public class Description
    {
        public List<Hashtag> hashtags { get; set; }
        public List<Url> urls { get; set; }
        public List<Mention> mentions { get; set; }
    }

    public class Url2
    {
        public List<Url> urls { get; set; }
    }

    public class Entities
    {
        public Description description { get; set; }
        public Url url { get; set; }
        public List<Annotation> annotations { get; set; }
        public List<Url> urls { get; set; }
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
    }

    public class BlockData
    {
        public string url { get; set; }
        public string profile_image_url { get; set; }
        public bool verified { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string name { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public bool @protected { get; set; }
        public string username { get; set; }
        public string location { get; set; }
        public DateTime created_at { get; set; }
        public string pinned_tweet_id { get; set; }
    }

    public class Attachments
    {
        public List<string> media_keys { get; set; }
    }

    public class Annotation
    {
        public int start { get; set; }
        public int end { get; set; }
        public double probability { get; set; }
        public string type { get; set; }
        public string normalized_text { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
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

    public class Tweet
    {
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public Attachments attachments { get; set; }
        public string reply_settings { get; set; }
        public Entities entities { get; set; }
        public string conversation_id { get; set; }
        public DateTime created_at { get; set; }
        public string source { get; set; }
        public string text { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string id { get; set; }
        public string author_id { get; set; }
        public List<ContextAnnotation> context_annotations { get; set; }
    }

    public class Includes
    {
        public List<Tweet> tweets { get; set; }
    }

    public class Meta
    {
        public int result_count { get; set; }
    }

    public class BlocksModel
    {
        public List<BlockData> data { get; set; }
        public Includes includes { get; set; }
        public Meta meta { get; set; }
    }


}
