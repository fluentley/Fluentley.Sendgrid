using Fluentley.SendGrid.Operations.Campaigns.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Campaigns.Validators
{
    internal class DeleteCampaignCommandValidator : AbstractValidator<DeleteCampaignCommand>
    {
       

        public DeleteCampaignCommandValidator()
        {
            
        }
    }
}