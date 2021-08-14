namespace SocialOpinionAPI.DTO.Likes
{
    public class LikeTweetDTO
    {
        public string tweet_id { get; set; }
    }

    public class LikeTweetResponseDTO
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public bool liked { get; set; }
    }

    public class UnLikeTweetResponseDTO
    {
        public Data data { get; set; }
    }
}
