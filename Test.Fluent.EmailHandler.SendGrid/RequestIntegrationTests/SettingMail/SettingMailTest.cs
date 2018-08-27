using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.SettingMail
{
    [TestClass]
    public class SettingMailTest : BaseTest
    {
        #region EnforcedTls

        [TestMethod]
        public async Task UpdateBccSettingTest()
        {
            var result = await Service.UpdateBccSetting(option => option
                .EmailAddress("example@example.com")
                .IsEnabled(false)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/bcc", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateBccSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateEmailAddressWhiteListSettingTest()
        {
            var result = await Service.UpdateEmailAddressWhiteListSetting(option => option
                .IsEnabled(true)
                .AddEmailAddress("email1@example.com")
                .AddEmailAddress("example.com")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/address_whitelist", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateEmailAddressWhiteListSetting",
                    result.Data));
        }

        [TestMethod]
        public async Task UpdateBouncePurgeSettingTest()
        {
            var result = await Service.UpdateBouncePurgeSetting(option => option
                .IsEnabled(true)
                .NumberOfHardBounces(5)
                .NumberOfSoftBounces(5)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/bounce_purge", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateBouncePurgeSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateBounceForwardSettingTest()
        {
            var result = await Service.UpdateBounceForwardSetting(option => option
                .IsEnabled(true)
                .EmailAddress("emailAddress")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/forward_bounce", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateBounceForwardSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateMailFooterSettingTest()
        {
            var result = await Service.UpdateMailFooterSetting(option => option
                .IsEnabled(true)
                .HtmlContent("...")
                .PlainContent("...")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/footer", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateMailFooterSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdatePlainContentSettingTest()
        {
            var result = await Service.UpdatePlainContentSetting(option => option
                .IsEnabled(false)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/plain_content", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdatePlainContentSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateSpamCheckSettingTest()
        {
            var result = await Service.UpdateSpamCheckSetting(option => option
                .IsEnabled(false)
                .Url("http://example.com")
                .MaxScore(6)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/spam_check", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateSpamCheckSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateSpamForwardingSettingTest()
        {
            var result = await Service.UpdateSpamForwardingSetting(option => option
                .EmailAddress("example@example.com")
                .IsEnabled(false)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/forward_spam", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateSpamForwardingSetting", result.Data));
        }

        [TestMethod]
        public async Task UpdateTemplateSettingTest()
        {
            var result = await Service.UpdateTemplateSetting(option => option
                .HtmlContent("<p><% body %>Example</p>\n")
                .IsEnabled(false)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/template", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SettingMail.Results.UpdateTemplateSetting", result.Data));
        }

        [TestMethod]
        public async Task BccSettingTest()
        {
            var result =
                await Service.BccSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/bcc", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task BounceForwardSettingTest()
        {
            var result =
                await Service.BounceForwardSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/forward_bounce", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task BouncePurgeSettingTest()
        {
            var result =
                await Service.BouncePurgeSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/bounce_purge", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task EmailAddressWhiteListSettingTest()
        {
            var result =
                await Service.EmailAddressWhiteListSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/address_whitelist", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task MailFooterSettingTest()
        {
            var result =
                await Service.MailFooterSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/footer", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task PlainContentSettingTest()
        {
            var result =
                await Service.PlainContentSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/plain_content", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SpamCheckSettingTest()
        {
            var result =
                await Service.SpamCheckSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/spam_check", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SpamForwardingSettingTest()
        {
            var result =
                await Service.SpamForwardingSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/forward_spam", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task TemplateSettingTest()
        {
            var result =
                await Service.TemplateSetting().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings/template", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.MailSettings(option => option.UsePaging(0, 10)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/mail_settings?offset=0&limit=10", requestResult.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}