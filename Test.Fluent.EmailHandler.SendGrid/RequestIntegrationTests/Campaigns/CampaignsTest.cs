using Fluentley.SendGrid.Operations.Campaigns.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Fluentley.SendGrid.RequestIntegrationTests.Campaigns
{
    [TestClass]
    public class CampaignsTest : BaseTest
    {
        #region Campaigns

        [TestMethod]
        public async Task CreateTest()
        {
            var campaign = new Campaign
            {
                Title = "March Newsletter",
                Subject = "New Products for Spring!",
                SenderId = 124451,
                ListIds = new List<int>
                {
                    110,
                    124
                },
                SegmentIds = new List<int>
                {
                    110
                },
                Categories = new List<string>
                {
                    "spring line"
                },
                SuppressionGroupId = 42,
                CustomUnsubscribeUrl = "",
                IpPool = "marketing",
                HtmlContent = "<html><head><title></title></head><body><p>Check out our spring line!</p></body></html>",
                PlainContent = "Check out our spring line!"
            };

            var result = await Service.CreateCampaign(option => option.ByModel(campaign)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns", result.Data.RequestUri.AbsoluteUri);

            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.Campaigns.Results.CreateCampaign", result.Data));
        }

        [TestMethod]
        public async Task SendTest()
        {
            var result = await Service.SendCampaign(option => option.ById("1")).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("POST", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1/schedules/now", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var campaign = new Campaign
            {
                Id = "1",
                Title = "May Newsletter",
                Subject = "New Products for Summer!",
                Categories = new List<string>
                {
                    "summer line"
                },
                HtmlContent = "<html><head><title></title></head><body><p>Check out our summer line!</p></body></html>",
                PlainContent = "Check out our summer line!"
            };

            var result = await Service.UpdateCampaign(option => option.ByModel(campaign)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.Campaigns.Results.UpdateCampaign", result.Data));
        }

        /*[TestMethod]
        public async Task ScheduleACampaignTest()
        {
            //todo: Need to refactor
            var scheduledDate = new DateTime(2017, 03, 17, 5, 25, 0);
            var result = await Service
                .UpdateCampaign(option => option
                    .Id("1")
                    .ChangeScheduledTimeInUtc(scheduledDate)
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("PATCH", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1/schedules", result.Data.RequestUri.AbsoluteUri);
            Assert.AreEqual(true,
                CompareJsons("RequestIntegrationTests.Campaigns.Results.ScheduleACampaign", result.Data));
        }*/

        [TestMethod]
        public async Task DeleteTest()
        {
            var campaign = new Campaign
            {
                Id = "1"
            };

            var result = await Service.DeleteCampaign(option => option.ByModel(campaign)).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("DELETE", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1", result.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task ListTest()
        {
            var requestResult = await Service.Campaigns().GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", requestResult.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, requestResult.IsSuccess);
            Assert.AreEqual("GET", requestResult.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns", requestResult.Data.RequestUri.AbsoluteUri);
        }

        [TestMethod]
        public async Task SingleTest()
        {
            var result =
                await Service.CampaignById(option => option
                    .ById("1")
                ).GenerateRequest();

            Assert.AreEqual($"Bearer {SendGridApiKey}", result.Data.Headers.Authorization.ToString());
            Assert.AreEqual(true, result.IsSuccess);
            Assert.AreEqual("GET", result.Data.Method.Method);
            Assert.AreEqual($"{EndPoint}/campaigns/1", result.Data.RequestUri.AbsoluteUri);
        }

        #endregion
    }
}