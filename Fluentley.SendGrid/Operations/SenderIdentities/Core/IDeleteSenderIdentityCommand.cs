using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Core
{
    public interface IDeleteSenderIdentityCommand : IContextQuery<IDeleteSenderIdentityCommand>

    {
        IDeleteSenderIdentityCommand ById(string id);
        IDeleteSenderIdentityCommand ByModel(SenderIdentity model);
    }
}