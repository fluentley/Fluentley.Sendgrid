﻿using System;
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
using Fluentley.SendGrid.Operations.CampaignSchedules.Models;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.Campaigns.Commands
{
    internal class CampaignSendCommand : AbstractCommand<CampaignSchedule, CampaignSendCommand>, ICampaignSendCommand,
        ICommand<CampaignSchedule>
    {
        public CampaignSendCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private DateTime? SendAtDateTime { get; set; }

        [JsonProperty("send_at")]
        internal long? SendAt => SendAtDateTime?.ToUnixTime();

        [JsonProperty("to")]
        internal string TestEmailTo { get; set; }

        [JsonIgnore]
        internal string Id { get; set; }

        public ICampaignSendCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public ICampaignSendCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public ICampaignSendCommand ByModel(Campaign value)
        {
            Id = value?.Id;
            return this;
        }

        public Task<IResult<CampaignSchedule>> Execute()
        {
            return Processor.Process<CampaignSchedule, ICampaignSendCommand, CampaignSendCommand>(this,
                context => context.SendCampaignById(this));
        }

        public Task<IResult<CampaignSchedule>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<CampaignSendCommand>(commandJson);

            return Processor.Process<CampaignSchedule, ICampaignSendCommand, CampaignSendCommand>(this,
                context => context.SendCampaignById(command));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<CampaignSchedule, ICampaignSendCommand, CampaignSendCommand>(this,
                context => context.SendCampaignById(this));
        }

        public ICampaignSendCommand ScheduleOnUtc(DateTime value)
        {
            SendAtDateTime = value;
            return this;
        }

        public ICampaignSendCommand IsTest(string value)
        {
            TestEmailTo = value;
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new CampaignSendCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}