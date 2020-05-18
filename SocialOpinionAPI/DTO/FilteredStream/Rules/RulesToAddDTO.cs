using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.FilteredStream
{

    public class RulesToAddDTO
    {
        public List<Add> add { get; set; }

        public RulesToAddDTO()
        {
            add = new List<Add>();
        }
    }

    public class Add
    {
        public string value { get; set; }
        public string tag { get; set; }
    }
}
