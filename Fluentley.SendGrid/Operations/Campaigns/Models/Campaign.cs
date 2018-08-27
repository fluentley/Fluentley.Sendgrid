using System.Collections.Generic;
using Fluentley.SendGrid.Operations.CampaignSchedules.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Campaigns.Models
{
    public class Campaign
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("sender_id")]
        public int SenderId { get; set; }

        [JsonProperty("list_ids")]
        public IList<int> ListIds { get; set; }

        [JsonProperty("segment_ids")]
        public IList<int> SegmentIds { get; set; }

        [JsonProperty("categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty("suppression_group_id")]
        public int SuppressionGroupId { get; set; }

        [JsonProperty("custom_unsubscribe_url")]
        public string CustomUnsubscribeUrl { get; set; }

        [JsonProperty("ip_pool")]
        public string IpPool { get; set; }

        [JsonProperty("html_content")]
        public string HtmlContent { get; set; }

        [JsonProperty("plain_content")]
        public string PlainContent { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public CampaignSchedule CampaignSchedule { get; set; }
    }
}