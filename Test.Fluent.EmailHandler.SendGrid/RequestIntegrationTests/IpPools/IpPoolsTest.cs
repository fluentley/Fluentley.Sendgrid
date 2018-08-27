using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.IpPools
{
    [TestClass]
    public class IpPoolsTest : BaseTest
    {
        [TestMethod]
        public async Task IpoolListTest()
        {
            var requestResult = await Service.IpPools().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task IpoolSingleTest()
        {
            var ipPoolName = "pool";
            var result =
                await Service.IpAddressByIpPool(option => option
                    .ByName(ipPoolName)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools/{ipPoolName}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var ipPoolName = "marketing";

            var result = await Service.CreateIpPool(option => option
                    .Name(ipPoolName))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true, CompareJsons("RequestIntegrationTests.IpPools.Results.AddIpPoolName", result.Data));
        }

        /*[TestMethod]
        public async Task AddIpAddressToIpPoolTest()
        {
            const string ipAddress = "192.168.1.1";
            var ipPoolName = "marketing";

            var result = await Service.AddIpAddressToPool(option => option
                    .PoolName(ipPoolName).IpAddress(ipAddress))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools/{ipPoolName}/ips", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.IpPools.Results.AddIpAddressToIpPool", result.Data));
        }*/

        [TestMethod]
        public async Task RemoveIpAddressToIpPoolTest()
        {
            const string ipAddress = "192.168.1.1";
            var ipPoolName = "marketing";

            var result = await Service.RemoveIpAddressFromPool(option => option
                    .PoolName(ipPoolName).IpAddress(ipAddress))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools/{ipPoolName}/ips/{ipAddress}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var ipPoolName = "marketing";

            var result = await Service.UpdateIpPool(option => option
                    .ChangeName(ipPoolName, ipPoolName))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PUT", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools/{ipPoolName}", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.IpPools.Results.UpdateIpPoolName", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var ipPoolName = "marketing";
            var result = await Service.DeleteIpPool(option => option.ByName(ipPoolName)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/pools/{ipPoolName}", result.Data.RequestUri.AbsoluteUri);
        }
    }
}