using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.Reputations
{
    [TestClass]
    public class ReputationsTest : BaseTest
    {
        #region Reputations

        [TestMethod]
        public async Task ListTest()
        {
            var subUser = "test";
            var requestResult = await Service.Reputations(option => option
                .AddSubUser(subUser)
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/subusers/reputations?usernames={subUser}",
                requestResult.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}