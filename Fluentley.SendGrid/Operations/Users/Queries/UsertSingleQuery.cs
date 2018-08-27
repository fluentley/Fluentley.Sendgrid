using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Users.Models;

namespace Fluentley.SendGrid.Operations.Users.Queries
{
    public interface IUserSingleQuery : IContextQuery<IUserSingleQuery>
    {
        IUserSingleQuery EagerLoadUserAccount(Action<IUserAccountSingleQuery> queryAction = null);
        IUserSingleQuery EagerLoadUserEmailAddress(Action<IUserEmailAddressSingleQuery> queryAction = null);
        IUserSingleQuery EagerLoadUserCredit(Action<IUserCreditSingleQuery> queryAction = null);
        IUserSingleQuery EagerLoadUserProfile(Action<IUserProfileSingleQuery> queryAction = null);
    }

    internal class UserSingleQuery : AbstractSingleQuery<User>, IUserSingleQuery, IQuery<User>
    {
        public UserSingleQuery(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private string Id { get; set; }
        internal UserAccountSingleQuery UserAccountSingleQuery { get; set; }

        internal UserEmailAddressSingleQuery UserEmailAddressSingleQuery { get; set; }

        internal UserCreditSingleQuery UserCreditSingleQuery { get; set; }

        internal UserProfileSingleQuery UserProfileSingleQuery { get; set; }

        public async Task<IResult<User>> Execute()
        {
            var result = await QueryProcessor.Process<User, IUserSingleQuery, UserSingleQuery>(this,
                context => context.User());

            if (result.IsSuccess && result.Data != null)
                if (UserAccountSingleQuery != null)
                {
                    UserAccountSingleQuery.UseContextOption(ContextOptionAction);

                    var userAccountSingleQueryResult = await UserAccountSingleQuery.Execute();

                    if (userAccountSingleQueryResult.IsSuccess)
                        result.Data.UserAccount = userAccountSingleQueryResult.Data;
                }

            if (result.IsSuccess && result.Data != null)
                if (UserProfileSingleQuery != null)
                {
                    UserProfileSingleQuery.UseContextOption(ContextOptionAction);

                    var userProfileSingleQueryResult = await UserProfileSingleQuery.Execute();

                    if (userProfileSingleQueryResult.IsSuccess)
                        result.Data.UserProfile = userProfileSingleQueryResult.Data;
                }

            if (result.IsSuccess && result.Data != null)
                if (UserEmailAddressSingleQuery != null)
                {
                    UserEmailAddressSingleQuery.UseContextOption(ContextOptionAction);

                    var userEmailAddressSingleQueryResult = await UserEmailAddressSingleQuery.Execute();

                    if (userEmailAddressSingleQueryResult.IsSuccess)
                        result.Data.UserEmailAddress = userEmailAddressSingleQueryResult.Data;
                }

            if (result.IsSuccess && result.Data != null)
                if (UserCreditSingleQuery != null)
                {
                    UserCreditSingleQuery.UseContextOption(ContextOptionAction);

                    var userCreditSingleQueryResult = await UserCreditSingleQuery.Execute();

                    if (userCreditSingleQueryResult.IsSuccess)
                        result.Data.UserCredit = userCreditSingleQueryResult.Data;
                }

            return result;
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<User, IUserSingleQuery, UserSingleQuery>(this,
                context => context.User());
        }

        public IUserSingleQuery UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public IUserSingleQuery EagerLoadUserAccount(Action<IUserAccountSingleQuery> queryAction = null)
        {
            UserAccountSingleQuery =
                OptionProcessor.Process<IUserAccountSingleQuery, UserAccountSingleQuery>(queryAction);
            return this;
        }

        public IUserSingleQuery EagerLoadUserEmailAddress(Action<IUserEmailAddressSingleQuery> queryAction = null)
        {
            UserEmailAddressSingleQuery =
                OptionProcessor.Process<IUserEmailAddressSingleQuery, UserEmailAddressSingleQuery>(queryAction);
            return this;
        }

        public IUserSingleQuery EagerLoadUserCredit(Action<IUserCreditSingleQuery> queryAction = null)
        {
            UserCreditSingleQuery =
                OptionProcessor.Process<IUserCreditSingleQuery, UserCreditSingleQuery>(queryAction);
            return this;
        }

        public IUserSingleQuery EagerLoadUserProfile(Action<IUserProfileSingleQuery> queryAction = null)
        {
            UserProfileSingleQuery =
                OptionProcessor.Process<IUserProfileSingleQuery, UserProfileSingleQuery>(queryAction);
            return this;
        }
    }
}