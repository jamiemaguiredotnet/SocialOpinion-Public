using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Following
{

    public class Datum
    {
        public PublicMetrics public_metrics { get; set; }
        public string url { get; set; }
        public string profile_image_url { get; set; }
        public string location { get; set; }
        public Entities entities { get; set; }
        public string pinned_tweet_id { get; set; }
        public bool verified { get; set; }
        public DateTime created_at { get; set; }
        public string id { get; set; }
        public bool is_protected { get; set; }
        public string description { get; set; }
        public string username { get; set; }
        public string name { get; set; }
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

    public class PublicMetrics
    {
        public int followers_count { get; set; }
        public int following_count { get; set; }
        public int tweet_count { get; set; }
        public int listed_count { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
    }

    public class Description
    {
        public IList<Mention> mentions { get; set; }
        public IList<Hashtag> hashtags { get; set; }
        public IList<Url> urls { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
    }

    public class Entities
    {
        public Url url { get; set; }
        public Description description { get; set; }
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

    public class Meta
    {
        public int result_count { get; set; }
        public string next_token { get; set; }
    }

    public class FollowingIncludes
    {
        public IList<DTO.Users.Tweet> tweets { get; set; }
        public Meta meta { get; set; }
    }

    public class FollowingModel
    {
        public IList<Datum> data { get; set; }
        public IList<Error> errors { get; set; }
        public Meta meta { get; set; }
    }
}
