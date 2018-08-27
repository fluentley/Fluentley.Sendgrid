using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.SenderIdentities.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.SenderIdentities.Validators
{
    internal class UpdateSenderIdentityCommandValidator : AbstractValidator<UpdateSenderIdentityCommand>
    {
        private readonly Context _context;

        public UpdateSenderIdentityCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<UpdateSenderIdentityCommand> context,
            ValidationResult result)
        {
            var findResult = _context.SenderIdentityById(context.InstanceToValidate?.Id).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "SenderIdentity does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}