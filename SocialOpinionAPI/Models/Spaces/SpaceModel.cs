using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.Models.Spaces
{

    public class SpaceModel
    {
        public Data data { get; set; }
        public Includes includes { get; set; }
        public Meta meta { get; set; }
    }

    public class SpacesModel
    {
        public List<Data> data { get; set; }
        public Includes includes { get; set; }
        public Meta meta { get; set; }
    }

    public class Data
    {
        public string lang { get; set; }
        public DateTime created_at { get; set; }
        public DateTime started_at { get; set; }
        public DateTime updated_at { get; set; }
        public string state { get; set; }
        public DateTime scheduled_start { get; set; }
        public string title { get; set; }
        public List<string> host_ids { get; set; }
        public bool is_ticketed { get; set; }
        public int participant_count { get; set; }
        public string id { get; set; }
        public string creator_id { get; set; }
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
        public List<Mention> mentions { get; set; }
    }

    public class Entities
    {
        public Url url { get; set; }
        public Description description { get; set; }
    }

    public class User
    {
        public string url { get; set; }
        public DateTime created_at { get; set; }
        public bool @protected { get; set; }
        public string description { get; set; }
        public string profile_image_url { get; set; }
        public bool verified { get; set; }
        public string location { get; set; }
        public string id { get; set; }
        public string pinned_tweet_id { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public string username { get; set; }
        public Entities entities { get; set; }
        public string name { get; set; }
    }

    public class Includes
    {
        public List<User> users { get; set; }
    }

    public class Meta
    {
        public int result_count { get; set; }
    }
}

