using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Likes
{
   
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Annotation
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("normalized_text")]
        public string NormalizedText { get; set; }
    }

    public class Url
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("url")]
        public string UrlValue { get; set; }

        [JsonProperty("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }
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

    public class Entities
    {
        [JsonProperty("annotations")]
        public List<Annotation> Annotations { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

        [JsonProperty("hashtags")]
        public List<Hashtag> Hashtags { get; set; }

        [JsonProperty("url")]
        public Url Url { get; set; }

        [JsonProperty("description")]
        public Description Description { get; set; }
    }

    public class ReferencedTweet
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class PublicMetrics
    {
        [JsonProperty("retweet_count")]
        public int RetweetCount { get; set; }

        [JsonProperty("reply_count")]
        public int ReplyCount { get; set; }

        [JsonProperty("like_count")]
        public int LikeCount { get; set; }

        [JsonProperty("quote_count")]
        public int QuoteCount { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        [JsonProperty("tweet_count")]
        public int TweetCount { get; set; }

        [JsonProperty("listed_count")]
        public int ListedCount { get; set; }
    }

    public class Domain
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Entity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ContextAnnotation
    {
        [JsonProperty("domain")]
        public Domain Domain { get; set; }

        [JsonProperty("entity")]
        public Entity Entity { get; set; }
    }

    public class Datum
    {
        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("in_reply_to_user_id")]
        public string InReplyToUserId { get; set; }

        [JsonProperty("reply_settings")]
        public string ReplySettings { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("author_id")]
        public string AuthorId { get; set; }

        [JsonProperty("referenced_tweets")]
        public List<ReferencedTweet> ReferencedTweets { get; set; }

        [JsonProperty("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }

        [JsonProperty("context_annotations")]
        public List<ContextAnnotation> ContextAnnotations { get; set; }
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

        [JsonProperty("hashtags")]
        public List<Hashtag> Hashtags { get; set; }

        [JsonProperty("mentions")]
        public List<Mention> Mentions { get; set; }
    }

    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("pinned_tweet_id")]
        public string PinnedTweetId { get; set; }
    }

    public class Tweet
    {
        [JsonProperty("reply_settings")]
        public string ReplySettings { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("entities")]
        public Entities Entities { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("author_id")]
        public string AuthorId { get; set; }

        [JsonProperty("referenced_tweets")]
        public List<ReferencedTweet> ReferencedTweets { get; set; }

        [JsonProperty("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [JsonProperty("public_metrics")]
        public PublicMetrics PublicMetrics { get; set; }
    }

    public class Includes
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("tweets")]
        public List<Tweet> Tweets { get; set; }
    }

    public class Meta
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }

        [JsonProperty("next_token")]
        public string NextToken { get; set; }
    }

    public class LikesDTO
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("includes")]
        public Includes Includes { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }


}
