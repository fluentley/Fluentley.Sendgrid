using System.Collections.Generic;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Fluentley.SendGrid.Operations.MonitorSettings.Models;
using Fluentley.SendGrid.Operations.Reputations.Models;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.SubUsers.Models
{
    public class SubUser
    {
        [JsonProperty("disabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string UserName { get; set; }

        public List<Reputation> Reputations { get; set; }

        public MonitorSetting MonitorSetting { get; set; }
        public List<EmailReport> BlockedEmailReports { get; set; }
        public List<EmailReport> InvalidEmailReports { get; set; }
        public List<EmailReport> BouncedEmailReports { get; set; }
        public List<SpamReportedEmailAddress> SpamReportedEmails { get; set; }
        public List<Alert> Alerts { get; set; }
        public List<ApiKey> ApiKeys { get; set; }
    }
}