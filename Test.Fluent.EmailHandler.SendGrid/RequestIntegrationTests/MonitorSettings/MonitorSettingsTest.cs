using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.MonitorSettings
{
    [TestClass]
    public class MonitorSettingsTest : BaseTest
    {
        #region MonitorSettings

        [TestMethod]
        public async Task UpdateTest()
        {
            var subUserName = "test";
            var result = await Service.UpdateMonitorSetting(option => option
                .SubUserName(subUserName)
                .Frequency(500)
                .EmailAddress("example@example.com")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PUT", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/subusers/{subUserName}/monitor", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.MonitorSettings.Results.UpdateMonitorSettings", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var subUserName = "test";
            var result = await Service.DeleteMonitorSetting(option => option.ByUserName(subUserName)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/subusers/{subUserName}/monitor", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var subUserName = "test";
            var result =
                await Service.MonitorSetting(option => option
                    .BySubUserName(subUserName)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/subusers/{subUserName}/monitor", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}