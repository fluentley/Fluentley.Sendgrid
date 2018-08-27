using System.Net.Http;
using Newtonsoft.Json;
using RestEase;

namespace Fluentley.SendGrid.Contexts.Extensions
{
    internal static class RestClientExtensions
    {
        public static RestClient AddJsonBodySerializer(this RestClient client)
        {
            client.RequestBodySerializer = new JsonRequestBodySerializer();
            return client;
        }

        private class JsonRequestBodySerializer : RequestBodySerializer
        {
            /// <summary>
            ///     Gets or sets the serializer settings to pass to JsonConvert.SerializeObject
            /// </summary>
            public JsonSerializerSettings JsonSerializerSettings { get; set; }

            /// <inheritdoc />
            public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
            {
                if (body == null)
                    return null;
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.None,
                    NullValueHandling = NullValueHandling.Ignore
                };
                var content = new StringContent(JsonConvert.SerializeObject(body, JsonSerializerSettings));
                content.Headers.ContentType.MediaType = "application/json";
                return content;
            }
        }
    }
}