using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.ApiKeys.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.ApiKeys
{
    [TestClass]
    public class ApiKeysTest : BaseTest
    {
        #region ApiKeys

        [TestMethod]
        public async Task CreateTest()
        {
            var apiKey = new ApiKey
            {
                Name = "My API Key"
            };

            var result = await Service.CreateApiKey(option => option.ByModel(apiKey)
                .AddScope(Scope.MailSend, Scope.AlertCreate, Scope.AlertRead)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/api_keys", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true, CompareJsons("RequestIntegrationTests.ApiKeys.Results.CreateApiKey", result.Data));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var result = await Service.UpdateApiKey(option => option
                .Id("1")
                .Name("A New Hope")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/api_keys/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true, CompareJsons("RequestIntegrationTests.ApiKeys.Results.UpdateApiKey", result.Data));
        }

        [TestMethod]
        public async Task UpdateWithScopesTest()
        {
            //Needs some work.

            var result = await Service.UpdateApiKey(option => option
                .ResetScopes()
                .AddToExistingScopes(Scope.ReadUserProfile, Scope.UpdateUserProfile)
                .Id("1")
                .Name("A New Hope")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PUT", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/api_keys/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.ApiKeys.Results.UpdateApiKeyWithScopes", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteApiKey(option => option.ById("1")).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/api_keys/1", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.ApiKeys().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/api_keys", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.ApiKeyById(option => option
                    .ById("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/api_keys/1", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}