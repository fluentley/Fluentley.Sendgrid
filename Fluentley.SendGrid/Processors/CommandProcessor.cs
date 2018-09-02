using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Contexts;
using Newtonsoft.Json;
using RestEase;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fluentley.SendGrid.Processors
{
    internal class CommandProcessor
    {
        private readonly string _apiKey;

        public CommandProcessor(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<IResult<T>> Process<T, TInterfaceCommand, TCommand>(TCommand command,
            Func<Context, Task<Response<T>>> operation)
            where TInterfaceCommand : IContextQuery<TInterfaceCommand>
            where TCommand : AbstractCommand<T, TCommand>, TInterfaceCommand, ICommand<T>
        {
            var result = new Result<T>
            {
                CommandJson = JsonConvert.SerializeObject(command)
            };
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey);

                if (command?.ContextOption != null)
                    context = command?.ContextOption?.Process(context);


                var operationResult = await operation(context);

                if (!operationResult.ResponseMessage.IsSuccessStatusCode)
                    throw new Exception(
                        $"{operationResult.ResponseMessage.ReasonPhrase} - {operationResult.StringContent}");

                result.Data = operationResult.GetContent();
                result.IsSuccess = true;

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