using System.IO;
using System.Net.Http;
using System.Reflection;
using Fluentley.SendGrid;
using Newtonsoft.Json.Linq;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests
{
    public abstract class BaseTest
    {
        protected const string EndPoint = "https://api.sendgrid.com/v3";
        protected const string SendGridApiKey = "{{SendGridKey}}";
        protected readonly SendGridService Service;

        public BaseTest()
        {
            Service = new SendGridService(SendGridApiKey);
        }

        private string ReadEmbededResource(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Test.Fluentley.SendGrid.{fileName}.json";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public bool CompareJsons(string resourceName, HttpRequestMessage request)
        {
            return JToken.DeepEquals(JToken.Parse(ReadEmbededResource(resourceName)),
                JToken.Parse(request.Content.ReadAsStringAsync().Result));
        }
    }
}