using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.SettingMail.Models;

namespace Fluentley.SendGrid.Operations.SettingMail.Core
{
    public interface IUpdateBouncePurgeSettingCommand : IContextQuery<IUpdateBouncePurgeSettingCommand>

    {
        IUpdateBouncePurgeSettingCommand ByModel(BouncePurgeSetting value);
        IUpdateBouncePurgeSettingCommand NumberOfHardBounces(int value);
        IUpdateBouncePurgeSettingCommand NumberOfSoftBounces(int value);
        IUpdateBouncePurgeSettingCommand IsEnabled(bool value);
    }
}