using Newtonsoft.Json;

namespace SocialOpinionAPI.DTO.HideReplies
{
    public class HideReplyDTO
    {
        [JsonProperty("hidden")]
        public bool hidden { get; set; }
    }
}
