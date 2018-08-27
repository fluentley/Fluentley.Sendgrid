﻿using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Models
{
    public class Dkim
    {
        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }
    }
}