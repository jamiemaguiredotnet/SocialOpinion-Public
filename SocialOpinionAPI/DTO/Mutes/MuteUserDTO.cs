using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Mutes
{
    public class MuteUserDTO
    {
        public string target_user_id { get; set; }
    }

    public class MuteUserResponseDTO
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public bool muting { get; set; }
    }
}
