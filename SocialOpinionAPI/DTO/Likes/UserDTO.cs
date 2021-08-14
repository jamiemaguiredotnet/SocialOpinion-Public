using System.Collections.Generic;

namespace SocialOpinionAPI.DTO.Likes
{
    public class UserDTO
    {
        public List<User> data { get; set; }
        public Meta meta { get; set; }
    }
}
