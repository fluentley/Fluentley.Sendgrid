using System;
using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Users.Core
{
    public interface IUserSingleQuery : IContextQuery<IUserSingleQuery>
    {
        IUserSingleQuery EagerLoadUserAccount(Action<IUserAccountSingleQuery> queryAction = null);
        IUserSingleQuery EagerLoadUserEmailAddress(Action<IUserEmailAddressSingleQuery> queryAction = null);
        IUserSingleQuery EagerLoadUserCredit(Action<IUserCreditSingleQuery> queryAction = null);
        IUserSingleQuery EagerLoadUserProfile(Action<IUserProfileSingleQuery> queryAction = null);
    }
}