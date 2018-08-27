using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.SettingEnforcedTls.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.SettingEnforcedTls
{
    [TestClass]
    public class EnforcedTlsTest : BaseTest
    {
        #region EnforcedTls

        [TestMethod]
        public async Task UpdateTest()
        {
            var enforcedTls = new EnforcedTls
            {
                RequireTls = true,
                RequireValidCert = false
            };
            var result = await Service.UpdateEnforcedTls(option => option.ByModel(enforcedTls)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/settings/enforced_tls", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingEnforcedTls.Results.UpdateEnforcedTls", result.Data));
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.EnforcedTls().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/user/settings/enforced_tls", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}