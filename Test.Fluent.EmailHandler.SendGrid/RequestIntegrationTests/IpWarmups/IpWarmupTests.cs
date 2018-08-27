using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.IpWarmups
{
    [TestClass]
    public class IpWarmupTests : BaseTest
    {
        [TestMethod]
        public async Task CreateTest()
        {
            const string ipAddress = "192.168.1.1";

            var result = await Service.CreateIpWarmup(option => option.IpAddress(ipAddress)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/warmup", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true, CompareJsons("RequestIntegrationTests.IpWarmups.Results.AddIpWarmups", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            const string ipAddress = "192.168.1.1";

            var result = await Service.RemoveAnIpFromWarmup(option => option.ByIpAddress(ipAddress)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/warmup/{ipAddress}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.IpWarmups().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/warmup", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            const string ipAddress = "192.168.1.1";
            var result =
                await Service.IpWarmupById(option => option
                    .ByIpAddress(ipAddress)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/warmup/{ipAddress}", result.Data.RequestUri.AbsoluteUri);
        }
    }
}