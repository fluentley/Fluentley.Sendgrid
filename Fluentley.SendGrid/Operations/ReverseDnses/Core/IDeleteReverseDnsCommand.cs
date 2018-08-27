using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Core
{
    public interface IDeleteReverseDnsCommand : IContextQuery<IDeleteReverseDnsCommand>

    {
        IDeleteReverseDnsCommand ById(string id);
    }
}