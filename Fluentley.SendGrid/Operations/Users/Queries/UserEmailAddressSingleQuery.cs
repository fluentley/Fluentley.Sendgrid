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
    internal class UserEmailAddressSingleQuery : AbstractSingleQuery<UserEmailAddress>, IUserEmailAddressSingleQuery,
        IQuery<UserEmailAddress>
    {
        public UserEmailAddressSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<UserEmailAddress>> Execute()
        {
            return QueryProcessor.Process<UserEmailAddress, IUserEmailAddressSingleQuery, UserEmailAddressSingleQuery>(
                this,
                context => context.UserEmailAddress());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<UserEmailAddress, IUserEmailAddressSingleQuery, UserEmailAddressSingleQuery>(
                    this,
                    context => context.UserEmailAddress());
        }

        public IUserEmailAddressSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}