using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Models;

namespace Fluentley.SendGrid.Operations.Users.Queries
{
    public interface IUserAccountSingleQuery : IContextQuery<IUserAccountSingleQuery>

    {
    }

    internal class UserAccountSingleQuery : AbstractSingleQuery<UserAccount>, IUserAccountSingleQuery,
        IQuery<UserAccount>
    {
        public UserAccountSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<UserAccount>> Execute()
        {
            return QueryProcessor.Process<UserAccount, IUserAccountSingleQuery, UserAccountSingleQuery>(this,
                context => context.UserAccount());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<UserAccount, IUserAccountSingleQuery, UserAccountSingleQuery>(this,
                context => context.UserAccount());
        }

        public IUserAccountSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}