using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Core;
using Fluentley.SendGrid.Operations.Users.Models;

namespace Fluentley.SendGrid.Operations.Users.Queries
{
    internal class UserCreditSingleQuery : AbstractSingleQuery<UserCredit>, IUserCreditSingleQuery, IQuery<UserCredit>
    {
        public UserCreditSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<UserCredit>> Execute()
        {
            return QueryProcessor.Process<UserCredit, IUserCreditSingleQuery, UserCreditSingleQuery>(this,
                context => context.UserCredit());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<UserCredit, IUserCreditSingleQuery, UserCreditSingleQuery>(this,
                context => context.UserCredit());
        }

        public IUserCreditSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}