using Fluentley.SendGrid.Operations.Campaigns.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Campaigns.Validators
{
    internal class UpdateCampaignCommandValidator : AbstractValidator<UpdateCampaignCommand>
    {
        public UpdateCampaignCommandValidator()
        {
            RuleFor(x => x.IdOfCampaign).NotEmpty();
        }
    }
}