using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialOpinionAPI.DTO.Spaces
{
    public class Data
    {
        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("is_ticketed")]
        public bool IsTicketed { get; set; }

        [JsonProperty("participant_count")]
        public int ParticipantCount { get; set; }

        [JsonProperty("scheduled_start")]
        public DateTime ScheduledStart { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("host_ids")]
        public List<string> HostIds { get; set; }

        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }
    }

}
