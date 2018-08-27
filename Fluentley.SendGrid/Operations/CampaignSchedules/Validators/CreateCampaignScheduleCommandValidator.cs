using Fluentley.SendGrid.Operations.CampaignSchedules.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Validators
{
    internal class CreateCampaignScheduleCommandValidator : AbstractValidator<CreateCampaignScheduleCommand>
    {
        public CreateCampaignScheduleCommandValidator()
        {
            RuleFor(x => x.ScheduleCampaignId).NotNull().NotEmpty();
        }
    }
}