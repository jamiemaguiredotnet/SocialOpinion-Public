using System;

namespace SocialOpinionAPI.DTO.Tweets
{
    public class PostTweetDTO
    {
        public string text { get; set; }
    }

    public class PostTweetResponseDTO
    {
        public PostTweet data { get; set; }
    }

    public class PostTweet
    {
        public string id { get; set; }
        public string text { get; set; }
    }
}