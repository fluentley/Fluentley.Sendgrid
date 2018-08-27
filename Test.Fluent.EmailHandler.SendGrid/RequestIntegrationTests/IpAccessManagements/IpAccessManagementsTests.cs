using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.IpAccessManagements
{
    [TestClass]
    public class IpAccessManagementsTests : BaseTest
    {
        [TestMethod]
        public async Task CreateTest()
        {
            const string ipAddress = "192.168.1.1";

            var result = await Service.AddWhiteListedIpAddress(option => option
                .Add(ipAddress)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/access_settings/whitelist", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.IpAccessManagements.Results.AddWhiteListedIpAddress",
                    result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            const string id = "1";

            var result = await Service.RemoveWhiteListedIpAddress(option => option.IpAddressId(id)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/access_settings/whitelist", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.IpAccessManagements.Results.RemoveWhiteListedIpAddress",
                    result.Data));
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.WhiteListedIpAddressList().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/access_settings/whitelist", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task IpAccessManagementSettingActivityTest()
        {
            var requestResult = await Service.IpAccessManagementSettingActivity().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/access_settings/activity", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.WhiteListedIpAddressSingle(option => option
                    .ById("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/access_settings/whitelist/1", result.Data.RequestUri.AbsoluteUri);
        }
    }
}