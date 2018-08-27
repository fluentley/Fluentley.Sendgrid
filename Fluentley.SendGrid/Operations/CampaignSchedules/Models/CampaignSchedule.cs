using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Models
{
    public class CampaignSchedule
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("send_at")]
        public int SendAt { get; set; }
    }
}