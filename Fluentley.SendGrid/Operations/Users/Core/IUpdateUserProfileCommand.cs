using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.Users.Models;

namespace Fluentley.SendGrid.Operations.Users.Core
{
    public interface IUpdateUserProfileCommand : IContextQuery<IUpdateUserProfileCommand>

    {
        IUpdateUserProfileCommand ByModel(UserProfile userProfile);
    }
}