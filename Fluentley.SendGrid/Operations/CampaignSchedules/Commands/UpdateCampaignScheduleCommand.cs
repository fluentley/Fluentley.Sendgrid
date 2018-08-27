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
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Commands
{
    internal class UpdateCampaignScheduleCommand : AbstractCommand<CampaignSchedule, UpdateCampaignScheduleCommand>,
        IUpdateCampaignScheduleCommand,
        ICommand<CampaignSchedule>
    {
        public UpdateCampaignScheduleCommand(string defaultApikey) : base(defaultApikey)
        {
        }

        internal string ScheduleCampaignId { get; set; }

        private DateTime? ScheduledTime { get; set; }

        [JsonProperty("send_at")]
        internal long? SendAt => ScheduledTime?.ToUnixTime();

        public Task<IResult<CampaignSchedule>> Execute()
        {
            return Processor.Process<CampaignSchedule, IUpdateCampaignScheduleCommand, UpdateCampaignScheduleCommand>(
                this,
                context => context.UpdateScheduleCampaignById(this) /*, context =>
                {
                    var validator = new UpdateCampaignScheduleCommandValidator(context);
                    return validator.ValidateAsync(this);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator
                .Process<CampaignSchedule, IUpdateCampaignScheduleCommand, UpdateCampaignScheduleCommand>(
                    this,
                    context => context.UpdateScheduleCampaignById(this) /*, context =>
                    {
                        var validator = new UpdateCampaignScheduleCommandValidator(context);
                        return validator.ValidateAsync(this);
                    }*/);
        }

        public IUpdateCampaignScheduleCommand CampaignId(string id)
        {
            ScheduleCampaignId = id;
            return this;
        }

        public IUpdateCampaignScheduleCommand ScheduleOnUtc(DateTime value)
        {
            ScheduledTime = value;
            return this;
        }

        public IUpdateCampaignScheduleCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}