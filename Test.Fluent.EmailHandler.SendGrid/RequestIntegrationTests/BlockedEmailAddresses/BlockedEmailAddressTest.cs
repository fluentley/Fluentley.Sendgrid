using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.BlockedEmailAddresses
{
    [TestClass]
    public class BlockedEmailAddressTest : BaseTest
    {
        #region BlockedEmailAddresss

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteBlockedEmailAddress(option => option
                .AddForDeletion("example1@example.com")
                .AddForDeletion("example2@example.com")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/blocks", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.BlockedEmailAddresses.Results.DeleteEmailAddress", result.Data));
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.BlockedEmailAddresses().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/blocks", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.BlockedEmailAddressById(option => option
                    .ByEmailAddress("example1@example.com")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/blocks/example1@example.com",
                HttpUtility.UrlDecode(result.Data.RequestUri.AbsoluteUri));
        }

        #endregion
    }
}