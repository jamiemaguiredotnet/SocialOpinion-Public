namespace SocialOpinionAPI.DTO.Retweet
{
    public class RetweetDTO
    {
        public string tweet_id { get; set; }
    }
    
    public class RetweetResponseDTO
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public bool retweeted { get; set; }
    }
}
