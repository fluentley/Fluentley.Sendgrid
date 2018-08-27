using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Core
{
    public interface ISetupReverseDnsCommand : IContextQuery<ISetupReverseDnsCommand>

    {
        ISetupReverseDnsCommand IpAddress(string ipAdddress);
        ISetupReverseDnsCommand SubDomain(string subDomain);
        ISetupReverseDnsCommand Domain(string domain);
    }
}