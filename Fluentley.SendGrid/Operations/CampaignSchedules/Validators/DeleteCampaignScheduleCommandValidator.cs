using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Validators
{
    internal class DeleteCampaignScheduleCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteCampaignScheduleCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.CampaignById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "CampaignSchedule does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}