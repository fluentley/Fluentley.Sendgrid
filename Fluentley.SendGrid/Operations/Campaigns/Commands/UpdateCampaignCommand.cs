using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Extensions;
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
    internal class UpdateCampaignCommand : AbstractCommand<Campaign, UpdateCampaignCommand>, IUpdateCampaignCommand,
        ICommand<Campaign>
    {
        private readonly SendGridService _service;

        public UpdateCampaignCommand(string defaultApiKey) : base(defaultApiKey)
        {
            _service = new SendGridService(defaultApiKey);
        }

        [JsonProperty("id")]
        internal string IdOfCampaign { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty("html_content")]
        public string HtmlContent { get; set; }

        [JsonProperty("plain_content")]
        public string PlainContent { get; set; }

        private DateTime? ScheduledTime { get; set; }

        [JsonProperty("send_at")]
        internal long? SendAt => ScheduledTime?.ToUnixTime();

        public Task<IResult<Campaign>> Execute()
        {
            return Processor.Process<Campaign, IUpdateCampaignCommand, UpdateCampaignCommand>(this,
                 context => context.UpdateCampaign(this));
        }

        public Task<IResult<Campaign>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<UpdateCampaignCommand>(commandJson);

            return Processor.Process<Campaign, IUpdateCampaignCommand, UpdateCampaignCommand>(this,
                context => context.UpdateCampaign(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<Campaign, IUpdateCampaignCommand, UpdateCampaignCommand>(this,
                 context => context.UpdateCampaign(this));
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new UpdateCampaignCommandValidator();
            return validator.ValidateAsync(this);
        }

        public IUpdateCampaignCommand ByModel(Campaign campaign)
        {
            if (campaign == null)
                return this;

            IdOfCampaign = campaign.Id;
            Title = campaign.Title;
            Subject = campaign.Subject;
            Categories = campaign.Categories;
            HtmlContent = campaign.HtmlContent;
            PlainContent = campaign.PlainContent;

            return this;
        }

        public IUpdateCampaignCommand Id(string id)
        {
            IdOfCampaign = id;
            return this;
        }

        public IUpdateCampaignCommand ChangeScheduledTimeInUtc(DateTime time)
        {
            ScheduledTime = time;
            return this;
        }

        public IUpdateCampaignCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}