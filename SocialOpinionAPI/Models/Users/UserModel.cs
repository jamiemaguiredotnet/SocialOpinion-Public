using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Users
{
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

    public class Description
    {
        public IList<Hashtag> hashtags { get; set; }
        public IList<Mention> mentions { get; set; }
    }

    public class Entities
    {
        public Url url { get; set; }
        public Description description { get; set; }
    }

    public class PublicMetrics
    {
        public int followers_count { get; set; }
        public int following_count { get; set; }
        public int tweet_count { get; set; }
        public int listed_count { get; set; }
    }

    public class Data
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

    public class Attachments
    {
        public IList<string> media_keys { get; set; }
    }

    public class Tweet
    {
        public Attachments attachments { get; set; }
        public string author_id { get; set; }
        public DateTime created_at { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }

    public class Includes
    {
        public IList<Tweet> tweets { get; set; }
    }

    public class UserModel
    {
        public Data data { get; set; }
        public Includes includes { get; set; }
    }

    public class UsersModel
    {
        public List<Data> data { get; set; }
        public Includes includes { get; set; }
    }

}
