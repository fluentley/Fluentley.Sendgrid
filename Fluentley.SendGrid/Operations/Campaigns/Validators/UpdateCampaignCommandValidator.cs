using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Campaigns.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.Campaigns.Validators
{
    internal class UpdateCampaignCommandValidator : AbstractValidator<UpdateCampaignCommand>
    {
        private readonly Context _context;

        public UpdateCampaignCommandValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.IdOfCampaign).NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<UpdateCampaignCommand> context, ValidationResult result)
        {
            var findResult = _context.CampaignById(context.InstanceToValidate?.IdOfCampaign).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "Campaign does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}