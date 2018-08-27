using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Fluentley.QueryBuilder;
using Fluentley.SendGrid.Common.Models;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Contexts;
using Newtonsoft.Json;
using RestEase;

namespace Fluentley.SendGrid.Processors
{
    internal class QueryProcessor
    {
        private readonly string _apiKey;

        public QueryProcessor(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<IResult<List<T>>> Process<T, TInterfaceQuery, TQuery>(TQuery query,
            Func<Context, Task<Response<List<T>>>> operation)
            where TInterfaceQuery : IListMemoryFilterQuery<TInterfaceQuery, T>, IContextQuery<TInterfaceQuery>
            where TQuery : AbstractListQuery<T>, TInterfaceQuery
            where T : class
        {
            var result = new Result<List<T>>();
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey);

                if (query?.ContextOption != null)
                    context = query.ContextOption.Process(context);

                var operationResult = await operation(context);

                if (!operationResult.ResponseMessage.IsSuccessStatusCode)
                    throw new Exception(
                        $"{operationResult.ResponseMessage.ReasonPhrase} - {operationResult.StringContent}");

                result.Data = operationResult.GetContent();
                result.IsSuccess = true;

                if (query?.QueryOptionAction != null)
                {
                    var queryResult = result.Data.QueryOn(query.QueryOptionAction);
                    result.Paging = queryResult.Paging;
                    result.Data = queryResult.Data.ToList();
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

        public async Task<IResult<List<T>>> Process<T, TInterfaceQuery, TQuery>(TQuery query,
            Func<Context, Task<Response<SendGridResult<List<T>>>>> operation)
            where TInterfaceQuery : IListMemoryFilterQuery<TInterfaceQuery, T>, IContextQuery<TInterfaceQuery>
            where TQuery : AbstractListQuery<T>, TInterfaceQuery
            where T : class
        {
            var result = new Result<List<T>>();
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey);

                if (query?.ContextOption != null)
                    context = query.ContextOption.Process(context);

                var operationResult = await operation(context);

                if (!operationResult.ResponseMessage.IsSuccessStatusCode)
                    throw new Exception(
                        $"{operationResult.ResponseMessage.ReasonPhrase} - {operationResult.StringContent}");

                result.Data = operationResult.GetContent().Result;
                result.IsSuccess = true;

                if (query?.QueryOptionAction != null)
                {
                    var queryResult = result.Data.QueryOn(query.QueryOptionAction);
                    result.Paging = queryResult.Paging;
                    result.Data = queryResult.Data.ToList();
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

        public async Task<IResult<T>> Process<T, TInterfaceQuery, TQuery>(TQuery query,
            Func<Context, Task<Response<T>>> operation)
            where TInterfaceQuery : IContextQuery<TInterfaceQuery>
            where TQuery : AbstractSingleQuery<T>, TInterfaceQuery
            where T : class
        {
            var result = new Result<T>();
            var watch = new Stopwatch();
            watch.Start();

            try
            {
                var context = new Context(_apiKey);
                if (query?.ContextOption != null)
                    context = query.ContextOption.Process(context);

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