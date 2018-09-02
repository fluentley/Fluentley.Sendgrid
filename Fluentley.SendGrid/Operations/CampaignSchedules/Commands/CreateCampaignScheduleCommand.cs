using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Extensions;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.CampaignSchedules.Core;
using Fluentley.SendGrid.Operations.CampaignSchedules.Models;
using Fluentley.SendGrid.Operations.CampaignSchedules.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Commands
{
    internal class CreateCampaignScheduleCommand : AbstractCommand<CampaignSchedule, CreateCampaignScheduleCommand>,
        ICreateCampaignScheduleCommand,
        ICommand<CampaignSchedule>
    {
        public CreateCampaignScheduleCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        private DateTime? ScheduledTime { get; set; }

        [JsonProperty("send_at")]
        internal long? SendAt => ScheduledTime?.ToUnixTime();

        internal string ScheduleCampaignId { get; set; }

        public Task<IResult<CampaignSchedule>> Execute()
        {
            return Processor.Process<CampaignSchedule, ICreateCampaignScheduleCommand, CreateCampaignScheduleCommand>(
                this,
                context => context.CreateCampaignSchedule(this));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<CampaignSchedule, ICreateCampaignScheduleCommand, CreateCampaignScheduleCommand>(
                    this,
                    context => context.CreateCampaignSchedule(this));
        }

        public ICreateCampaignScheduleCommand CampaignId(string id)
        {
            ScheduleCampaignId = id;
            return this;
        }

        public ICreateCampaignScheduleCommand ScheduleOnUtc(DateTime value)
        {
            ScheduledTime = value;
            return this;
        }

        public ICreateCampaignScheduleCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new CreateCampaignScheduleCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}