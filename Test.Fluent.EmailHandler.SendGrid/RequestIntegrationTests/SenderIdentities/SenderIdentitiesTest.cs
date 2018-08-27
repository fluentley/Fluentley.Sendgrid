using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.EmailOperations.Models;
using Fluentley.SendGrid.Operations.SenderIdentities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.SenderIdentities
{
    [TestClass]
    public class SenderIdentitiesTest : BaseTest
    {
        #region SenderIdentities

        [TestMethod]
        public async Task CreateTest()
        {
            var senderIdentity = new SenderIdentity
            {
                Address = "123 Elm St.",
                Address2 = "Apt. 456",
                City = "Denver",
                State = "Colorado",
                Zip = "80202",
                Country = "United States",
                ReplyTo = new EmailAddress("replyto@example.com", "Example INC"),
                From = new EmailAddress("from@example.com", "Example INC"),
                Nickname = "My Sender ID"
            };
            var result = await Service.CreateSenderIdentity(option => option.ByModel(senderIdentity)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/senders", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SenderIdentities.Results.CreateSenderIdentity", result.Data));
        }

        [TestMethod]
        public async Task ResendTest()
        {
            var id = "1";
            var result = await Service.ResendVerificationSenderIdentity(option => option.ById(id)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/senders/{id}/resend_verification", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var senderIdentity = new SenderIdentity
            {
                Id = "1",
                Address = "123 Elm St.",
                Address2 = "Apt. 456",
                City = "Denver",
                State = "Colorado",
                Zip = "80202",
                Country = "United States",
                ReplyTo = new EmailAddress("replyto@example.com", "Example INC"),
                From = new EmailAddress("from@example.com", "Example INC"),
                Nickname = "My Sender ID"
            };

            var result = await Service.UpdateSenderIdentity(option => option.ByModel(senderIdentity)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/senders/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.SenderIdentities.Results.UpdateSenderIdentity", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var id = "1";
            var result = await Service.DeleteSenderIdentity(option => option.ById(id)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/senders/{id}", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.SenderIdentities().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/senders", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.SenderIdentityById(option => option
                    .ById("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/senders/1", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}