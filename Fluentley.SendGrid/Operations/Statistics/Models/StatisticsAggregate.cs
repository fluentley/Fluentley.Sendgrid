using System.ComponentModel.DataAnnotations;

namespace Fluentley.SendGrid.Operations.Statistics.Models
{
    public enum StatisticsAggregate
    {
        [Display(Name = "")] None,
        [Display(Name = "day")] Day,
        [Display(Name = "week")] Week,
        [Display(Name = "month")] Month
    }
}