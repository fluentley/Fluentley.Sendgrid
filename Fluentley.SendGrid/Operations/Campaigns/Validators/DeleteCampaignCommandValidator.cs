using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.Campaigns.Validators
{
    internal class DeleteCampaignCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteCampaignCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.CampaignById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "Campaign does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}