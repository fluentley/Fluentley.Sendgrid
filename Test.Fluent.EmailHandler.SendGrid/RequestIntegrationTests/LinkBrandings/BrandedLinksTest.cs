using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.LinkBrandings
{
    [TestClass]
    public class BrandedLinksTest : BaseTest
    {
        #region BrandedLinks

        [TestMethod]
        public async Task CreateTest()
        {
            var result = await Service.CreateBrandedLink(option => option
                .DomainUrl("example.com")
                .SubDomain("mail")
                .IsDefault(true)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.LinkBrandings.Results.CreateBrandedLink", result.Data));
        }

        [TestMethod]
        public async Task AssociateBrandedForSubUserTest()
        {
            var result = await Service.AssociateBrandedForSubUser(option => option
                .SubUserName("test")
                .BrandedLinkId("1")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/1/subuser", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.LinkBrandings.Results.AssociateBrandedLink", result.Data));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var result = await Service.UpdateBrandedLink(option => option
                .IsDefault(true)
                .ById("1")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.LinkBrandings.Results.UpdateBrandedLink", result.Data));
        }

        [TestMethod]
        public async Task ValidateBrandedLinkTest()
        {
            var result = await Service.ValidateBrandedLink(option => option
                .ById("1")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/1/validate", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteBrandedLink(option => option.ById("1")).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/1", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task DisassociateBrandedForSubUserTest()
        {
            var result = await Service.DisassociateBrandedForSubUser(option => option
                .SubUserName("test")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/subuser?username=test", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.BrandedLinks()
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.BrandedLink(option => option
                    .ById("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/1", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleBySubuserTest()
        {
            var result =
                await Service.BrandedLinkForSubuser(option => option
                    .BySubUserName("user")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/subuser?username=user", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task DefaultBrandedLinkTest()
        {
            var result =
                await Service.DefaultBrandedLink(option => option
                    .FilterByDomainUrl("test")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/links/default?domain=test", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}