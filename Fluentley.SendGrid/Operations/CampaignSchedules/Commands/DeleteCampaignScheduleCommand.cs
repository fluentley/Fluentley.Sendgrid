using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluentley.SendGrid.Common.Commands;
using Fluentley.SendGrid.Common.Options.ContextOptions;
using Fluentley.SendGrid.Common.Queries;
using Fluentley.SendGrid.Common.ResultArguments;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Commands
{
    public interface IDeleteCampaignScheduleCommand : IContextQuery<IDeleteCampaignScheduleCommand>

    {
        IDeleteCampaignScheduleCommand ById(string id);
    }

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
                context => context.DeleteScheduleCampaignById(Id) /*, context =>
                {
                    var validator = new DeleteCampaignScheduleCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public Task<IResult<HttpRequestMessage>> GenerateRequest()
        {
            return RequestGenerator.Process<string, IDeleteCampaignScheduleCommand, DeleteCampaignScheduleCommand>(
                this,
                context => context.DeleteScheduleCampaignById(Id) /*, context =>
                {
                    var validator = new DeleteCampaignScheduleCommandValidator(context);
                    return validator.ValidateAsync(Id);
                }*/);
        }

        public IDeleteCampaignScheduleCommand ById(string id)
        {
            Id = id;
            return this;
        }

        public IDeleteCampaignScheduleCommand UseContextOption(Action<IContextOption> option)
        {
            ContextOptionAction = option;
            ContextOption = OptionProcessor.Process<IContextOption, ContextOption>(option);
            return this;
        }
    }
}