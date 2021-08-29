using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Spaces
{ 

    public class Url
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("url")]
        public string RawUrl { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }
    }

    public class Urls
    {
        [JsonProperty("urls")]
        public List<Url> UrlList { get; set; }
    }

    public class Mention
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public class Description
    {
        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }
    }

    public class Entities
    {
        [JsonProperty("url")]
        public Url Url { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    public class PublicMetrics
    {
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        [JsonProperty("tweet_count")]
        public int TweetCount { get; set; }

        [JsonProperty("listed_count")]
        public int ListedCount { get; set; }
    }

    public class User
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("pinned_tweet_id")]
        public string PinnedTweetId { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Includes
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }
    }

    public class Meta
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }
    }

    public class SpaceDTO
    {
        [JsonProperty("data")]
        public Data data { get; set; }

        [JsonProperty("includes")]
        public Includes includes { get; set; }
    }

    public class SpacesDTO
    {
        [JsonProperty("data")]
        public List<Data> Data { get; set; }

        [JsonProperty("includes")]
        public Includes Includes { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }



}
