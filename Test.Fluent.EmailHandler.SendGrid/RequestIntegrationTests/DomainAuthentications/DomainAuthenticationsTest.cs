using System.Collections.Generic;
using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.DomainAuthentications.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.DomainAuthentications
{
    [TestClass]
    public class DomainAuthenticationsTest : BaseTest
    {
        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.AuthenticatedDomainList(options => options
                .AssociatedUserName("user")
                .UsePaging(0, 10)
                .Domain("domain")
                .ExcludeSubusers(true)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual(
                $"{EndPoint}/whitelabel/domains?offset=0&limit=10&domain=domain&exclude_subusers=True&username=user",
                requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            const string id = "1";
            var result =
                await Service.AuthenticatedDomainSingle(option => option
                    .ById(id)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/{id}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleDefaultTest()
        {
            var result =
                await Service.DefaultAuthtenticatedDomainSingle().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/default", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListBySubUserTest()
        {
            var result =
                await Service.AuthenticatedDomainListForSubuser().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/subuser", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task AuthenticateDomain()
        {
            var model = new DomainAuthenticate
            {
                Domain = "example.com",
                Subdomain = "news",
                Username = "john@example.com",
                Ips = new List<string>
                {
                    "192.168.1.1",
                    "192.168.1.2"
                },
                CustomSpf = true,
                AutomaticSecurity = false,
                Default = true
            };
            var result = await Service.AuthenticateToDomain(option => option.ByModel(model)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.DomainAuthentications.Results.AuthenticateToDomain",
                    result.Data));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var model = new AuthenticatedDomainSetting
            {
                Id = "1",
                CustomSpf = true,
                Default = false
            };
            var result = await Service.UpdateAuthenticatedDomainSetting(option => option.ByModel(model))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.DomainAuthentications.Results.UpdateAuthenticatedDomain",
                    result.Data));
        }

        [TestMethod]
        public async Task AddIpAddressToAuthenticatedDomainTest()
        {
            const string id = "1";
            const string ipAddress = "192.168.0.1";

            var result = await Service
                .AddIpAddressToAuthenticatedDomain(option => option
                    .Id(id)
                    .IpAddress(ipAddress))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/{id}/ips", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.DomainAuthentications.Results.AddIpAddressToAuthenticatedDomain",
                    result.Data));
        }

        [TestMethod]
        public async Task RemoveIpAddressToAuthenticatedDomainTest()
        {
            const string id = "1";
            const string ipAddress = "192.168.0.1";

            var result = await Service
                .RemoveIpAddressToAuthenticatedDomain(option => option
                    .Id(id)
                    .IpAddress(ipAddress))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/{id}/ips/{ipAddress}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task AssociateSubuserToAuthenticatedDomainTest()
        {
            const string id = "1";
            var result = await Service
                .AssociateSubuserToAuthenticatedDomain(option => option
                    .DomainId(id)
                    .SubUser("jane@example.com"))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/{id}/subuser", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.DomainAuthentications.Results.AssociateSubuserToAuthenticated",
                    result.Data));
        }

        [TestMethod]
        public async Task DisAssociateSubuserToAuthenticatedDomain()
        {
            var result = await Service
                .DisAssociateSubuserToAuthenticatedDomain()
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/subuser", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task DeleteAuthenticatedDomainTest()
        {
            const string id = "1";
            var result = await Service
                .DeleteAuthenticatedDomain(option => option
                    .ById(id))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/{id}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ValidateAuthenticatedDomainTest()
        {
            const string id = "1";
            var result = await Service
                .ValidateAuthenticatedDomain(option => option
                    .ById(id))
                .GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/whitelabel/domains/{id}/validate", result.Data.RequestUri.AbsoluteUri);
        }
    }
}