using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.ApiKeys.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.ApiKeys.Validators
{
    internal class UpdateApiKeyCommandValidator : AbstractValidator<UpdateApiKeyCommand>
    {
        private readonly Context _context;

        public UpdateApiKeyCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<UpdateApiKeyCommand> context, ValidationResult result)
        {
            var findResult = _context.ApiKeyById(context.InstanceToValidate?.ApiKeyId).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "ApiKey does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}