using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.IpAddresses.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.IpAddresses
{
    [TestClass]
    public class IpAddressesTest : BaseTest
    {
        [TestMethod]
        public async Task RemaningIpAddressesTest()
        {
            var requestResult = await Service.RemaningIpAddresses().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/remaining", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task IpAddressesListTest()
        {
            const string ipAddress = "192.168.1.1";
            const string subUser = "user";
            var requestResult = await Service.IpAddresses(option => option
                    .UsePaging(0, 10)
                    .FilterByIpAddress(ipAddress)
                    .FilterBySubuser(subUser)
                    .ShouldExcludeWhiteLabels(true)
                    .SortBy(SortDirection.Ascending))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual(
                $"{EndPoint}/ips?offset=0&limit=10&sort_by_direction=asc&exclude_whitelabels=True&ip={ipAddress}&subuser={subUser}",
                requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task AssignedIpAddressesListTest()
        {
            var requestResult = await Service.AssignedIpAddresses().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/assigned", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task IpAddressesSingleTest()
        {
            const string ipAddress = "192.168.1.1";
            var result =
                await Service.IpAddress(option => option
                        .ByIpAddress(ipAddress))
                    .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips/{ipAddress}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task CreateTest()
        {
            var result = await Service.AddIpAddress(option => option
                .AddSubUser("subuser1")
                .AddSubUser("subuser2")
                .CountOfIpAddresses(90323478)
                .IsWarmUp(true)
                .UserCanSend(true)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/ips", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.IpAddresses.Results.AddIpAddress", result.Data));
        }
    }
}