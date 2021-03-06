﻿using System.Threading.Tasks;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Common.Commands
{
    public interface ICommand<T> : IGenerateRequest, IValidate
    {
        Task<IResult<T>> Execute();
        Task<IResult<T>> ExecuteCommand(string commandJson);
    }
}