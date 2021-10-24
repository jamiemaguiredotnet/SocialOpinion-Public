using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Mutes
{
  
    public class Url
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("url")]
        public string Urls { get; set; }

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

    public class Hashtag
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }

    public class Description
    {
        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

        [JsonProperty("hashtags")]
        public List<Hashtag> Hashtags { get; set; }
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

    public class Datum
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pinned_tweet_id")]
        public string PinnedTweetId { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }

    public class Error
    {
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("resource_id")]
        public string ResourceId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Meta
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }

        [JsonProperty("next_token")]
        public string NextToken { get; set; }
    }

    public class MutedUsersResponseDTO
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }




}
