using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.EmailCNameRecords.Core
{
    public interface ISendGeneratedDnsInformationCommand : IContextQuery<ISendGeneratedDnsInformationCommand>

    {
        ISendGeneratedDnsInformationCommand LinkId(string linkId);
        ISendGeneratedDnsInformationCommand DomainId(string domainId);
        ISendGeneratedDnsInformationCommand EmailAddress(string emailAddress);
        ISendGeneratedDnsInformationCommand Message(string message);
    }
}