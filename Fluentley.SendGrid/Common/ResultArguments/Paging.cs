namespace Fluentley.SendGrid.Common.ResultArguments
{
    public class Paging
    {
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}