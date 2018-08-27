using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.CampaignSchedules
{
    [TestClass]
    public class CampaignSchedulesTest : BaseTest
    {
        #region CampaignSchedules

        [TestMethod]
        public async Task CreateTest()
        {
            var result = await Service.CreateCampaignSchedule(option => option
                .CampaignId("1")
                .ScheduleOnUtc(new DateTime(2017, 03, 17, 17, 25, 28))
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1/schedules", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.CampaignSchedules.Results.CreateCampaignSchedule", result.Data));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var result = await Service.UpdateCampaignSchedule(option => option
                .CampaignId("1")
                .ScheduleOnUtc(new DateTime(2017, 03, 17, 17, 25, 28))
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1/schedules", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.CampaignSchedules.Results.CreateCampaignSchedule", result.Data));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            var result = await Service.DeleteCampaignSchedule(option => option
                .ById("1")
            ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1/schedules", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.CampaignScheduleByCampaignId(option => option
                    .ByCampaignId("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1/schedules", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}