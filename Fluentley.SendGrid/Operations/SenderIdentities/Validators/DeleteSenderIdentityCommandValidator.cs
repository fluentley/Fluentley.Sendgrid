using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Validators
{
    internal class DeleteSenderIdentityCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteSenderIdentityCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.SenderIdentityById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "SenderIdentity does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}