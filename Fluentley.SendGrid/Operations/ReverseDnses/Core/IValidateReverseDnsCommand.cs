using Fluentley.SendGrid.Common.Queries;

namespace Fluentley.SendGrid.Operations.ReverseDnses.Core
{
    public interface IValidateReverseDnsCommand : IContextQuery<IValidateReverseDnsCommand>

    {
        IValidateReverseDnsCommand ById(string id);
    }
}