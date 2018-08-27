using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.ReverseDnses
{
    [TestClass]
    public class ReverseDnsTest : BaseTest
    {
        #region ReverseDns

        [TestMethod]
        public async Task SetupTest()
        {
            var result = await Service.SetupReverseDns(option => option
                .SubDomain("email")
                .IpAddress("192.168.1.1")
                .Domain("example.com")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/ips", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.ReverseDnses.Results.SetupReverseDns", result.Data));
        }

        [TestMethod]
        public async Task ValidateTest()
        {
            var id = "1";

            var result = await Service.ValidateReverseDns(option => option
                .ById(id)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/ips/{id}/validate", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteReverseDns(option => option.ById("1")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/ips/1", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.ReverseDnsList().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/ips", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var id = "1";
            var result =
                await Service.ReverseDns(option => option
                    .ById(id)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/ips/{id}", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}