using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Timeline
{
    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
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

    public class Entities
    {
        public List<Mention> mentions { get; set; }
        public List<Annotation> annotations { get; set; }
        public List<Url> urls { get; set; }
        public Url url { get; set; }
        public Description description { get; set; }
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

    public class ReferencedTweet
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Geo
    {
        public string place_id { get; set; }
        public string type { get; set; }
        public List<double> bbox { get; set; }
        public Properties properties { get; set; }
    }

    public class Attachments
    {
        public List<string> media_keys { get; set; }
    }

    public class Meta
    {
        public string oldest_id { get; set; }
        public string newest_id { get; set; }
        public int result_count { get; set; }
        public string next_token { get; set; }
    }

    public class Datum
    {
        public string in_reply_to_user_id { get; set; }
        public Entities entities { get; set; }
        public string source { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string text { get; set; }
        public string reply_settings { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string author_id { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public Geo geo { get; set; }
        public Attachments attachments { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Cashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Description
    {
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
        public List<Url> urls { get; set; }
        public List<Cashtag> cashtags { get; set; }
    }

    public class User
    {
        public Entities entities { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string username { get; set; }
        public string location { get; set; }
        public string profile_image_url { get; set; }
        public bool @protected { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string pinned_tweet_id { get; set; }
        public string url { get; set; }
        public bool verified { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Tweet
    {
        public string in_reply_to_user_id { get; set; }
        public Entities entities { get; set; }
        public string source { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string text { get; set; }
        public string reply_settings { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string author_id { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public Attachments attachments { get; set; }
        public Geo geo { get; set; }
    }

    public class Properties
    {
    }

    public class Place
    {
        public string id { get; set; }
        public string country_code { get; set; }
        public string place_type { get; set; }
        public string country { get; set; }
        public Geo geo { get; set; }
        public string full_name { get; set; }
        public string name { get; set; }
    }

    public class Medium
    {
        public string media_key { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public string preview_image_url { get; set; }
        public int? duration_ms { get; set; }
    }

    public class Includes
    {
        public List<User> users { get; set; }
        public List<Tweet> tweets { get; set; }
        public List<Place> places { get; set; }
        public List<Medium> media { get; set; }
    }

    public class UserMentionedTimelineItemModel
    {
        public Datum data { get; set; }
        public Includes includes { get; set; }
    }

    public class UserMentionedTimelineModel
    {
        public List<Datum> data { get; set; }
        public Includes includes { get; set; }
        public Meta meta { get; set; }
    }

}
