using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface ICreateBrandedLinkCommand : IContextQuery<ICreateBrandedLinkCommand>

    {
        ICreateBrandedLinkCommand DomainUrl(string value);
        ICreateBrandedLinkCommand SubDomain(string value);
        ICreateBrandedLinkCommand IsDefault(bool value);
    }
}