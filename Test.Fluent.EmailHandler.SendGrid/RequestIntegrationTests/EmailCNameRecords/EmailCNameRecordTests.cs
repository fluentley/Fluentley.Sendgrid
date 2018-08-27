using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.EmailCNameRecords
{
    [TestClass]
    public class EmailCNameRecordTests : BaseTest
    {
        [TestMethod]
        public async Task SendGeneratedDnsInformationTest()
        {
            var result = await Service.SendGeneratedDnsInformation(option => option
                    .DomainId("46873408")
                    .EmailAddress("Dsn7WXsc@BaYOAhTnGdtVmb.zzuz")
                    .LinkId("29719392"))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/dns/email", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.EmailCNameRecords.Results.SendGenerateDnsInformation",
                    result.Data));
        }
    }
}