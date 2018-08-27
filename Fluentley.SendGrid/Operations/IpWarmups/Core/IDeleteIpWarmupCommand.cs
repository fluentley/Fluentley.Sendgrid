using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.IpWarmups.Models;

namespace Fluentley.SendGrid.Operations.IpWarmups.Core
{
    public interface IDeleteIpWarmupCommand : IContextQuery<IDeleteIpWarmupCommand>

    {
        IDeleteIpWarmupCommand ByIpAddress(string ipAddress);
        IDeleteIpWarmupCommand ByModel(IpWarmup model);
    }
}