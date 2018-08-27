using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Validators
{
    internal class DeleteAuthenticatedDomainCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteAuthenticatedDomainCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.AuthenticatedDomainById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "AuthenticatedDomain does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}