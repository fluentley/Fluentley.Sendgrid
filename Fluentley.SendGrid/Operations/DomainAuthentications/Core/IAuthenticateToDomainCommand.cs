using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IAuthenticateToDomainCommand : IContextQuery<IAuthenticateToDomainCommand>

    {
        IAuthenticateToDomainCommand ByModel(DomainAuthenticate value);
    }
}