using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Contexts;
using Newtonsoft.Json;
using RestEase;

namespace Fluentley.SendGrid.Processors
{
    internal class QueryRequestGenerator
    {
        private readonly string _apiKey;

        public QueryRequestGenerator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<IResult<HttpRequestMessage>> Process<T, TInterfaceQuery, TQuery>(TQuery query,
            Func<Context, Task<Response<List<T>>>> operation)
            where TInterfaceQuery : IListMemoryFilterQuery<TInterfaceQuery, T>, IContextQuery<TInterfaceQuery>
            where TQuery : AbstractListQuery<T>, TInterfaceQuery
            where T : class
        {
            var result = new Result<HttpRequestMessage>();
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey, false);

                if (query?.ContextOption != null)
                    context = query.ContextOption.Process(context);

                var operationResult = await operation(context);

                result.Data = operationResult.ResponseMessage.RequestMessage;
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

        public async Task<IResult<HttpRequestMessage>> Process<T, TInterfaceQuery, TQuery>(TQuery query,
            Func<Context, Task<Response<SendGridResult<List<T>>>>> operation)
            where TInterfaceQuery : IListMemoryFilterQuery<TInterfaceQuery, T>, IContextQuery<TInterfaceQuery>
            where TQuery : AbstractListQuery<T>, TInterfaceQuery
            where T : class
        {
            var result = new Result<HttpRequestMessage>();
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey, false);

                if (query?.ContextOption != null)
                    context = query.ContextOption.Process(context);

                var operationResult = await operation(context);

                result.Data = operationResult.ResponseMessage.RequestMessage;
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

        public async Task<IResult<HttpRequestMessage>> Process<T, TInterfaceQuery, TQuery>(TQuery query,
            Func<Context, Task<Response<T>>> operation)
            where TInterfaceQuery : IContextQuery<TInterfaceQuery>
            where TQuery : AbstractSingleQuery<T>, TInterfaceQuery
            where T : class
        {
            var result = new Result<HttpRequestMessage>();
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey, false);

                if (query?.ContextOption != null)
                    context = query.ContextOption.Process(context);

                var operationResult = await operation(context);

                result.Data = operationResult.ResponseMessage.RequestMessage;
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