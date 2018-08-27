using System;
using System.Collections.Generic;
using Fluentley.QueryBuilder.Models;
using Fluentley.SendGrid.Common.Extensions;
using Fluentley.SendGrid.Common.Models;

namespace Fluentley.SendGrid.Common.ResultArguments
{
    public class Result<T> : IResult<T>
    {
        public Result()
        {
            // ValidationErrors = new List<string>();
            ErrorMessages = new List<ErrorMessage>();
        }

        public Exception Exception { get; set; }

        public bool IsSuccess { get; set; }

        public TimeSpan ExecutionDuration { get; set; }

        public T Data { get; set; }

        public List<ErrorMessage> ErrorMessages { get; set; }

        public QueryPaging Paging { get; set; }
        public string CommandJson { get; set; }

        public string ModelType => typeof(T).DelaredGenericType().Name;
    }
}