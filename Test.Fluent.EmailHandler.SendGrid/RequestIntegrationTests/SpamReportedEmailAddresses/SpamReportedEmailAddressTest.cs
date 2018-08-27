using System.Threading.Tasks;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.SpamReportedEmailAddresses
{
    [TestClass]
    public class SpamReportedEmailAddressTest : BaseTest
    {
        #region SpamReportedEmailAddressTest

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteSpamReportedEmailAddress(option => option
                .AddForDeletion("example1@example.com")
                .AddForDeletion("example2@example.com")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/spam_reports", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SpamReportedEmailAddresses.Results.DeleteEmailAddress",
                    result.Data));
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.SpamReportedEmailAddresses().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/spam_reports", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.SpamReportedEmailAddressById(option => option
                    .ByEmailAddress("example1@example.com")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/suppression/spam_reports/example1@example.com",
                HttpUtility.UrlDecode(result.Data.RequestUri.AbsoluteUri));
        }

        #endregion
    }
}