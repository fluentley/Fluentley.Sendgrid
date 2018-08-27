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
    internal class UserProfileSingleQuery : AbstractSingleQuery<UserProfile>, IUserProfileSingleQuery,
        IQuery<UserProfile>
    {
        public UserProfileSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }

        public Task<IResult<UserProfile>> Execute()
        {
            return QueryProcessor.Process<UserProfile, IUserProfileSingleQuery, UserProfileSingleQuery>(this,
                context => context.UserProfile());
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<UserProfile, IUserProfileSingleQuery, UserProfileSingleQuery>(this,
                context => context.UserProfile());
        }

        public IUserProfileSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IUserProfileSingleQuery ById(string id)
        {
            Id = id;
            return this;
        }
    }
}