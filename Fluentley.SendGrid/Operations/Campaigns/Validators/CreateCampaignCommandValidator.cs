using Fluentley.SendGrid.Operations.Campaigns.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Campaigns.Validators
{
    internal class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommand>
    {
        public CreateCampaignCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}