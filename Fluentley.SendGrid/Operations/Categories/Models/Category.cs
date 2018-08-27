using System.Collections.Generic;
using Fluentley.SendGrid.Operations.Statistics.Models;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Categories.Models
{
    public class Category
    {
        [JsonProperty("Category")]
        public string Name { get; set; }

        public List<EmailStatistic> EmailStatistics { get; set; }
    }
}