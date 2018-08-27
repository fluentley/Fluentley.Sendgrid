using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Core
{
    public interface IResendVerificationSenderIdentityCommand : IContextQuery<IResendVerificationSenderIdentityCommand>

    {
        IResendVerificationSenderIdentityCommand ById(string id);
        IResendVerificationSenderIdentityCommand ByModel(SenderIdentity model);
    }
}