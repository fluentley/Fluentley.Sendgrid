using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Core
{
    public interface IUpdateAuthenticatedDomainSettingCommand : IContextQuery<IUpdateAuthenticatedDomainSettingCommand>

    {
        IUpdateAuthenticatedDomainSettingCommand ByModel(AuthenticatedDomainSetting value);
    }
}