using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Mutes
{

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

    public class UrlList
    {
        public List<Url> urls { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Description
    {
        public List<Mention> mentions { get; set; }
        public List<Url> urls { get; set; }
        public List<Hashtag> hashtags { get; set; }
    }

    public class Entities
    {
        public Url url { get; set; }
        public Description description { get; set; }
    }

    public class Datum
    {
        public DateTime created_at { get; set; }
        public string name { get; set; }
        public bool verified { get; set; }
        public string username { get; set; }
        public string pinned_tweet_id { get; set; }
        public bool @protected { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string id { get; set; }
        public Entities entities { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string profile_image_url { get; set; }
        public string url { get; set; }
    }

    public class Meta
    {
        public int result_count { get; set; }
    }

    public class MutesModel
    {
        public List<Datum> data { get; set; }
        public Meta meta { get; set; }
    }


}
