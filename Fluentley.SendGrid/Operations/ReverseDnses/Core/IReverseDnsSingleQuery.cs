using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Core
{
    public interface IReverseDnsSingleQuery : IContextQuery<IReverseDnsSingleQuery>

    {
        IReverseDnsSingleQuery ById(string id);
    }
}