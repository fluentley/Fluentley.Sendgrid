using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IUpdateBrandedLinkCommand : IContextQuery<IUpdateBrandedLinkCommand>

    {
        IUpdateBrandedLinkCommand IsDefault(bool value);
        IUpdateBrandedLinkCommand ById(string value);
    }
}