using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IValidateBrandedLinkCommand : IContextQuery<IValidateBrandedLinkCommand>

    {
        IValidateBrandedLinkCommand ById(string id);
        IValidateBrandedLinkCommand ByModel(BrandedLink model);
    }
}