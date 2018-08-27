using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Fluentley.SendGrid.Contexts.HttpClientHelpers
{
    internal class CustomHttpClientHandler : HttpClientHandler
    {
        private readonly bool _shouldSendRequest;

        public CustomHttpClientHandler(bool shouldSendRequest = true)
        {
            _shouldSendRequest = shouldSendRequest;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (_shouldSendRequest)
                return await base.SendAsync(request, cancellationToken);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = request,
                Content = new StringContent("")
            };
        }
    }
}