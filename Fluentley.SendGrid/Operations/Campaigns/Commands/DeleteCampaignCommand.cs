using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;
using Fluentley.SendGrid.Operations.Campaigns.Core;
using Fluentley.SendGrid.Operations.Campaigns.Models;

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
                context => context.DeleteCampaignById(Id) /*, context =>
                {
                    var validator = new DeleteCampaignCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteCampaignCommand, DeleteCampaignCommand>(this,
                context => context.DeleteCampaignById(Id) /*, context =>
                {
                    var validator = new DeleteCampaignCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
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
    }
}