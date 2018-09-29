using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.CampaignSchedules.Core;
using Fluentley.SendGrid.Operations.CampaignSchedules.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Commands
{
    internal class DeleteCampaignScheduleCommand : AbstractCommand<string, DeleteCampaignScheduleCommand>,
        IDeleteCampaignScheduleCommand,
        ICommand<string>
    {
        public DeleteCampaignScheduleCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        public string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteCampaignScheduleCommand, DeleteCampaignScheduleCommand>(this,
                context => context.DeleteScheduleCampaignById(Id));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteCampaignScheduleCommand>(commandJson);

            return Processor.Process<string, IDeleteCampaignScheduleCommand, DeleteCampaignScheduleCommand>(this,
                context => context.DeleteScheduleCampaignById(command.Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteCampaignScheduleCommand, DeleteCampaignScheduleCommand>(
                this,
                context => context.DeleteScheduleCampaignById(Id));
        }

        public IDeleteCampaignScheduleCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteCampaignScheduleCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteCampaignScheduleCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}