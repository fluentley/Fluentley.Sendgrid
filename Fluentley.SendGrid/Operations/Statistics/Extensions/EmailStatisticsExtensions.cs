using Fluentley.SendGrid.Operations.Statistics.Models;

namespace Fluentley.SendGrid.Operations.Statistics.Extensions
{
    public static class EmailStatisticsExtensions
    {
        public static string ToAggregateByString(this StatisticsAggregate aggregate)
        {
            switch (aggregate)
            {
                case StatisticsAggregate.Day:
                    return "day";
                case StatisticsAggregate.Week:
                    return "week";
                case StatisticsAggregate.Month:
                    return "month";
            }

            return null;
        }
    }
}