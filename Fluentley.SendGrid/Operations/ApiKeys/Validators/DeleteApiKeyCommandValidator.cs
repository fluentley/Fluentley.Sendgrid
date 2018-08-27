using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.ApiKeys.Validators
{
    internal class DeleteApiKeyCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteApiKeyCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.ApiKeyById(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "ApiKey does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}