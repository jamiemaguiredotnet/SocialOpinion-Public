using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.FilteredStream.Rules
{
    public class RuleDTO
    {
        public string id { get; set; }
        public string value { get; set; }
        public string tag { get; set; }
    }

    public class RulesDTO
    {
        public List<RuleDTO> data { get; set; }
        public Meta meta { get; set; }
    }



}
