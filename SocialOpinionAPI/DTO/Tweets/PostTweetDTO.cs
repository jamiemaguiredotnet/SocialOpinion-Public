using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Tweets
{
    public class PostTweetDTO
    {
        public string text { get; set; }
        public Media media { get; set; }

        public PostTweetDTO()
        {
            media = new Media();
        }
    }

    public class PostTextOnyTweetDTO
    {
        public string text { get; set; }
    }

    public class Media
    {
        public List<string> media_ids { get; set; }
        public Media()
        {
            media_ids = new List<string>();
        }
    }

    public class PostTweetResponseDTO
    {
        [Obsolete("This property is deprecated. Please use data instead.", false)]
        public DataV1 datav1 { get; set; }
        /// <summary>
        /// the V2 payload data
        /// </summary>
        public Data data { get; set; }
    }

    public class DataV1
    {
        public string id { get; set; }
        public string text { get; set; }
        public string created_at { get; set; }
        public string author_id { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public string source { get; set; }
    }

}
