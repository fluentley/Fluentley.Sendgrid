﻿using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Core
{
    public interface IUpdateSenderIdentityCommand : IContextQuery<IUpdateSenderIdentityCommand>

    {
        IUpdateSenderIdentityCommand ByModel(SenderIdentity senderIdentity);
    }
}