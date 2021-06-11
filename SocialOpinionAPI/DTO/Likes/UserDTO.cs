using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Likes
{

    public class UserDTO
    {
        public List<DTO.Likes.User> data { get; set; }
        public Meta meta { get; set; }
    }

}
