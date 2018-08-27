using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Operations.LinkBrandings.Models;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Core
{
    public interface IDeleteBrandedLinkCommand : IContextQuery<IDeleteBrandedLinkCommand>

    {
        IDeleteBrandedLinkCommand ById(string id);
        IDeleteBrandedLinkCommand ByModel(BrandedLink model);
    }
}