using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.CampaignSchedules.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.CampaignSchedules.Validators
{
    internal class UpdateCampaignScheduleCommandValidator : AbstractValidator<UpdateCampaignScheduleCommand>
    {
        private readonly Context _context;

        public UpdateCampaignScheduleCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<UpdateCampaignScheduleCommand> context,
            ValidationResult result)
        {
            var findResult = _context.CampaignById(context.InstanceToValidate?.ScheduleCampaignId).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "CampaignSchedule does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}