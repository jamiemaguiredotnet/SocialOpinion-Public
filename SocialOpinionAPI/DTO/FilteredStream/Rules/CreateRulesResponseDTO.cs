using SocialOpinionAPI.DTO.FilteredStream.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.FilteredStream.Rules
{
    public class Summary
    {
        public int created { get; set; }
        public int not_created { get; set; }
    }

    public class Meta
    {
        public DateTime sent { get; set; }
        public Summary summary { get; set; }
    }
    
    public class CreateRulesResponseDTO
    {
        public List<RuleDTO> data { get; set; }
        public Meta meta { get; set; }
    }
}
