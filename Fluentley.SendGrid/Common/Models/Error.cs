using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Common.Models
{
    public class Error
    {
        [JsonProperty("errors")]
        public IList<ErrorMessage> ErrorMessages { get; set; }

        public override string ToString()
        {
            return string.Join(", ", ErrorMessages.Select(x => x.Message));
        }
    }
}