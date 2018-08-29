using System.Threading.Tasks;
using Fluentley.SendGrid.Operations.Alerts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.Alerts
{
    [TestClass]
    public class AlertsTest : BaseTest
    {
        #region Alerts

        [TestMethod]
        public async Task CreateTest()
        {
            var alert = new Alert
            {
                EmailTo = "example@example.com",
                Frequency = Frequency.Daily,
                Type = AlertType.StatisticsNotification
            };

            var result = await Service.CreateAlert(option =>  option.ByModel(alert)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/alerts", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true, CompareJsons("RequestIntegrationTests.Alerts.Results.CreateAlert", result.Data));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var alert = new Alert
            {
                Id = "1",
                EmailTo = "example@example.com"
            };

            var result = await Service.UpdateAlert(option => option.ByModel(alert)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/alerts/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true, CompareJsons("RequestIntegrationTests.Alerts.Results.UpdateAlert", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var alert = new Alert
            {
                Id = "1",
                EmailTo = "developer.cengel@gmail.com",
                Frequency = Frequency.Monthly,
                Type = AlertType.StatisticsNotification,
                Percentage = 100
            };

            var result = await Service.DeleteAlert(option => option.ByModel(alert)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/alerts/1", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.Alerts().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/alerts", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.AlertById(option => option
                    .ById("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/alerts/1", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}