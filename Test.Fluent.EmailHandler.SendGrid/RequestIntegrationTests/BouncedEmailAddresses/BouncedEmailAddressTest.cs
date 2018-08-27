using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.BouncedEmailAddresses
{
    [TestClass]
    public class BouncedEmailAddressTest : BaseTest
    {
        #region BouncedEmailAddressTest

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteBouncedEmailAddress(option => option
                .AddForDeletion("example1@example.com")
                .AddForDeletion("example2@example.com")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/bounces", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.BouncedEmailAddresses.Results.DeleteEmailAddress", result.Data));
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.BouncedEmailAddresses().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/bounces", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.BouncedEmailAddressById(option => option
                    .ByEmailAddress("example1@example.com")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/bounces/example1@example.com",
                HttpUtility.UrlDecode(result.Data.RequestUri.AbsoluteUri));
        }

        #endregion
    }
}