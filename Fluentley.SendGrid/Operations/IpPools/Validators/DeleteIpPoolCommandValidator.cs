using Fluentley.SendGrid.Contexts;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.IpPools.Validators
{
    internal class DeleteIpPoolCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteIpPoolCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<string> context, ValidationResult result)
        {
            var findResult = _context.IpPoolByName(context.InstanceToValidate).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "IpPool does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}