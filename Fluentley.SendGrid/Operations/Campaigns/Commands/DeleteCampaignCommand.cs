using System;
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
    internal class DeleteCampaignCommand : AbstractCommand<string, DeleteCampaignCommand>, IDeleteCampaignCommand,
        ICommand<string>
    {
        public DeleteCampaignCommand(string defaultApiKey) : base(defaultApiKey)
        {
        }

        internal string Id { get; set; }

        public Task<IResult<string>> Execute()
        {
            return Processor.Process<string, IDeleteCampaignCommand, DeleteCampaignCommand>(this,
                context => context.DeleteCampaignById(Id));
        }

        public Task<IResult<string>> ExecuteCommand(string commandJson)
        {
            var command = JsonConvert.DeserializeObject<DeleteCampaignCommand>(commandJson);

            return Processor.Process<string, IDeleteCampaignCommand, DeleteCampaignCommand>(this,
                context => context.DeleteCampaignById(command.Id));
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteCampaignCommand, DeleteCampaignCommand>(this,
                context => context.DeleteCampaignById(Id));
        }

        public IDeleteCampaignCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteCampaignCommand ByModel(Campaign model)
        {
            Id = model?.Id;
            return this;
        }

        public IDeleteCampaignCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }

        public Task<ValidationResult> Validate()
        {
            var validator = new DeleteCampaignCommandValidator();
            return validator.ValidateAsync(this);
        }
    }
}