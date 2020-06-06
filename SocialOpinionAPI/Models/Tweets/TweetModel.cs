using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Tweets
{
    public class OrganicMetrics
    {
        public int impression_count { get; set; }
        public int like_count { get; set; }
        public int reply_count { get; set; }
        public int quote_count { get; set; }
    }

    public class PublicMetrics
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }

    public class Data
    {
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
        public string id { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public OrganicMetrics organic_metrics { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
    }

    public class Urls
    {
        public IList<Url> urls { get; set; }
    }

    public class Entities
    {
        public Url url { get; set; }
    }

    public class User
    {
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string pinned_tweet_id { get; set; }
        public string profile_image_url { get; set; }
        public bool is_protected { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public bool verified { get; set; }
    }

    public class Includes
    {
        public IList<User> users { get; set; }
    }

    public class TweetModel
    {
        public Data data { get; set; }
        public Includes includes { get; set; }
    }

    public class TweetsModel
    {
        public List<Data> data { get; set; }
        public Includes includes { get; set; }
    }



}
