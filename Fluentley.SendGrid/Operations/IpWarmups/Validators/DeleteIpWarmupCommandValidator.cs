using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.IpWarmups.Validators
{
    internal class DeleteIpWarmupCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteIpWarmupCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.IpWarmupByIpAddress(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "IpWarmup does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}