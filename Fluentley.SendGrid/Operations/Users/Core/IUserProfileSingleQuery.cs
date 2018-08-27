using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.Users.Core
{
    public interface IUserProfileSingleQuery : IContextQuery<IUserProfileSingleQuery>

    {
        IUserProfileSingleQuery ById(string id);
    }
}