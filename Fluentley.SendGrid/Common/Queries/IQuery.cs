using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Common.Queries
{
    public interface IQuery<T> : IGenerateRequest
    {
        Task<IResult<T>> Execute();
    }
}