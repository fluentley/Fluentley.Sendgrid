using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Campaigns.Core;
using Fluentley.SendGrid.Operations.Campaigns.Models;
using Fluentley.SendGrid.Operations.Campaigns.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Campaigns.Commands
{
    internal class CreateCampaignCommand : AbstractCommand<Campaign, CreateCampaignCommand>, ICreateCampaignCommand,
        ICommand<Campaign>
    {
        public CreateCampaignCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("sender_id")]
        public int SenderId { get; set; }

        [JsonProperty("list_ids")]
        public IList<int> ListIds { get; set; }

        [JsonProperty("segment_ids")]
        public IList<int> SegmentIds { get; set; }

        [JsonProperty("categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty("suppression_group_id")]
        public int SuppressionGroupId { get; set; }

        [JsonProperty("custom_unsubscribe_url")]
        public string CustomUnsubscribeUrl { get; set; }

        [JsonProperty("ip_pool")]
        public string IpPool { get; set; }

        [JsonProperty("html_content")]
        public string HtmlContent { get; set; }

        [JsonProperty("plain_content")]
        public string PlainContent { get; set; }

        public Task<IResult<Campaign>> Execute()
        {
            return Processor.Process<Campaign, ICreateCampaignCommand, CreateCampaignCommand>(this,
                context => context.CreateCampaign(this));
        }

        public Task<IResult<Campaign>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<CreateCampaignCommand>(commandJson);

            return Processor.Process<Campaign, ICreateCampaignCommand, CreateCampaignCommand>(this,
                context => context.CreateCampaign(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Campaign, ICreateCampaignCommand, CreateCampaignCommand>(this,
                context => context.CreateCampaign(this));
        }

        public ICreateCampaignCommand ByModel(Campaign campaign)
        {
            if (campaign == null)
                return this;

            Title = campaign.Title;
            Subject = campaign.Subject;
            Categories = campaign.Categories;
            SuppressionGroupId = campaign.SuppressionGroupId;
            ListIds = campaign.ListIds;
            SenderId = campaign.SenderId;
            IpPool = campaign.IpPool;
            HtmlContent = campaign.HtmlContent;
            PlainContent = campaign.PlainContent;
            CustomUnsubscribeUrl = campaign.CustomUnsubscribeUrl;
            SegmentIds = campaign.SegmentIds;

            return this;
        }

        public ICreateCampaignCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
           var validator = new CreateCampaignCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}