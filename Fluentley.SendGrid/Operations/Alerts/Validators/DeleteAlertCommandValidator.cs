using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.Alerts.Validators
{
    internal class DeleteAlertCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteAlertCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.AlertById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "Alert does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}