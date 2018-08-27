using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.SettingInboundParses
{
    [TestClass]
    public class ParseSettingsTest : BaseTest
    {
        #region ParseSettings

        [TestMethod]
        public async Task CreateTest()
        {
            var hostName = "myhostname";
            var result = await Service.CreateParseSetting(option => option
                .HostName(hostName)
                .Url("http://email.myhosthame.com")
                .SpamCheck(true)
                .SendRaw(false)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/webhooks/parse/settings", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingInboundParses.Results.CreateParseSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var hostName = "myhostname";
            var result = await Service.UpdateParseSetting(option => option
                .HostName(hostName)
                .Url("http://email.myhosthame.com")
                .SpamCheck(true)
                .SendRaw(false)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/webhooks/parse/settings/{hostName}", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingInboundParses.Results.UpdateParseSetting", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var hostName = "myhostname";
            var result = await Service.DeleteParseSetting(option => option.ByHostName(hostName)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/webhooks/parse/settings/{hostName}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.ParseSettings().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/webhooks/parse/settings", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var hostName = "myhostname";
            var result =
                await Service.ParseSettingById(option => option
                    .ByHostName(hostName)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/webhooks/parse/settings/{hostName}", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}