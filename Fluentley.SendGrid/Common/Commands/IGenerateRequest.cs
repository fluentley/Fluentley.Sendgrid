using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Common.Commands
{
    public interface IGenerateRequest
    {
        Task<IResult<HttpRequestMessage>> GenerateRequest();
    }
}