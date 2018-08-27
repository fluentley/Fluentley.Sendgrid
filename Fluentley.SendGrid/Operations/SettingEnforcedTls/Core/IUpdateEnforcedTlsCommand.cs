using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;

namespace Fluentley.SendGrid.Operations.SettingEnforcedTls.Core
{
    public interface IUpdateEnforcedTlsCommand : IContextQuery<IUpdateEnforcedTlsCommand>

    {
        IUpdateEnforcedTlsCommand ByModel(EnforcedTls value);
    }
}