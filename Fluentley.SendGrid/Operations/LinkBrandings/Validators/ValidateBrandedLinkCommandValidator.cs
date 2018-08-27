using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Validators
{
    internal class ValidateBrandedLinkCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public ValidateBrandedLinkCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.BrandedLinkById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "BrandedLink does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}