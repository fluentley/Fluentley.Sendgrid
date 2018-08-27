using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Fluentley.SendGrid.RequestIntegrationTests;

namespace Test.Fluentley.SendGrid
{
    [TestClass]
    public class SendEmailCommandTest : BaseTest
    {
        [TestMethod]
        public async Task SendEmailtest()
        {
            var filePath = @"C:\Users\cenge\OneDrive\Desktop\Test.txt";

            var result = await Service.SendEmail(sendEmailOption => sendEmailOption
                .From("cengel.emre@gmail.com")
                .ReplyTo("developer.cengel@gmail.com", "Developer Cengel")
                .Subject($"Test Email From Fluentley.SendGrid {DateTime.UtcNow:d}")
                .AddCategory("Test Message")
                .AddRecipient(recipientOption => recipientOption
                    .AddTo("a6061382@nwytg.net")
                    .AddSubstitution("{{FirstName}}", "Emre")
                    .AddSubstitution("{{LastName}}", "Cengel")
                    .AddSubstitution("{{Salutation}}", "Mr.")
                    .AddSubstitution("{{CommunicationReason}}", "{{BadNewsCommunication}}"))
                .AddRecipient(recipientOption => recipientOption
                    .AddTo("a6061382@nwytg.net")
                    .AddSubstitution("{{FirstName}}", "Asena")
                    .AddSubstitution("{{LastName}}", "Cengel")
                    .AddSubstitution("{{Salutation}}", "Mrs.")
                    .AddSubstitution("{{CommunicationReason}}", "{{GoodNewsCommunication}}"))
                .AddContentOption(contentOption => contentOption
                    .Value("{{Salutation}} {{LastName}}, <br> {{CommunicationReason}}")
                    .Type("text/html"))
                .AddAttachments(option => option
                    .FileName("Test File.txt")
                    .Content(Convert.ToBase64String(File.ReadAllBytes(filePath))))
                .AddSection("{{GoodNewsCommunication}}",
                    "{{FirstName}}, We contact you in order to give you a great news")
                .AddSection("{{BadNewsCommunication}}", "{{FirstName}}, Unfortunately, we have a bad news for you")
                .TrackingSettings(option => option
                    .ClickTracking(clickTrackingOption => clickTrackingOption
                        .Enable(true))
                    .OpenTracking(openTracking => openTracking
                        .Enable(true))
                    .SubscriptionTracking(openTracking => openTracking
                        .Enable(true))
                )
            ).GenerateRequest();

            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual("https://api.sendgrid.com/v3/mail/send", result.Data.RequestUri.AbsoluteUri);
        }
    }
}