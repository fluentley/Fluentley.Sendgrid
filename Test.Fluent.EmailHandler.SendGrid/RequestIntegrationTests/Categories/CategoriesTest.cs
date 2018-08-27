using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.Categories
{
    [TestClass]
    public class CategoriesTest : BaseTest
    {
        #region Categories

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.Categories(option => option
                    .FilterByName("test").UsePaging(0, 10)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/categories?limit=10&offset=0&category=test",
                result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}