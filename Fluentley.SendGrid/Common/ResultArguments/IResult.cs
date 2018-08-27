using System;
using System.Collections.Generic;
using Fluentley.QueryBuilder.Models;
using Fluentley.SendGrid.Common.Models;

namespace Fluentley.SendGrid.Common.ResultArguments
{
    public interface IResult
    {
        // string ErrorMessage { get; set; }
        TimeSpan ExecutionDuration { get; set; }

        bool IsSuccess { get; set; }

        // bool IsValid { get; set; }
        //  List<string> ValidationErrors { get; set; }
        List<ErrorMessage> ErrorMessages { get; set; }
        QueryPaging Paging { get; set; }

        string CommandJson { get; set; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; set; }
        string ModelType { get; }
    }
}