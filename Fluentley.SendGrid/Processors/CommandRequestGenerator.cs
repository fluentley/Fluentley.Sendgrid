﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Contexts;
using FluentValidation.Results;
using Newtonsoft.Json;
using RestEase;

namespace Fluentley.SendGrid.Processors
{
    internal class CommandRequestGenerator
    {
        private readonly string _apiKey;

        public CommandRequestGenerator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<IResult<HttpRequestMessage>> Process<T, TInterfaceCommand, TCommand>(TCommand command,
            Func<Context, Task<Response<T>>> operation,
            Func<Context, Task<ValidationResult>> validationOperation = null)
            where TInterfaceCommand : IContextQuery<TInterfaceCommand>
            where TCommand : AbstractCommand<T, TCommand>, TInterfaceCommand, ICommand<T>
        {
            var result = new Result<HttpRequestMessage>
            {
                CommandJson = JsonConvert.SerializeObject(command)
            };
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey, false);

                if (command?.ContextOption != null)
                    context = command?.ContextOption?.Process(context);

                var isValid = false;
                ValidationResult validationResult = null;

                if (validationOperation == null)
                {
                    isValid = true;
                }
                else
                {
                    validationResult = await validationOperation(context);
                    isValid = validationResult.IsValid;
                }

                if (!isValid)
                {
                    result.IsSuccess = false;
                    result.ErrorMessages.Add(new ErrorMessage(ErrorType.Validation, validationResult?.Errors));
                }
                else
                {
                    var operationResult = await operation(context);

                    result.Data = operationResult.ResponseMessage.RequestMessage;
                    result.IsSuccess = true;
                }
            }
            catch (ApiException exception)
            {
                var sendGridError = JsonConvert.DeserializeObject<Error>(exception.Content);

                result.IsSuccess = false;
                result.ErrorMessages.Add(new ErrorMessage(ErrorType.SendGrid, sendGridError.ErrorMessages.ToArray()));
                result.Exception = exception;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.ErrorMessages.Add(new ErrorMessage(ErrorType.Exception,
                    exception?.InnerException?.Message ?? exception.Message));
                result.Exception = exception;
            }
            finally
            {
                watch.Stop();
                result.ExecutionDuration = watch.Elapsed;
            }

            return result;
        }
    }
}