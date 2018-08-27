using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.IpPools.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.IpPools.Validators
{
    internal class RemoveIpAddressToPoolCommandValidator : AbstractValidator<RemoveIpAddressFromPoolCommand>
    {
        private readonly Context _context;

        public RemoveIpAddressToPoolCommandValidator(Context context)
        {
            _context = context;
        }

        protected override bool PreValidate(ValidationContext<RemoveIpAddressFromPoolCommand> context,
            ValidationResult result)
        {
            var findResult = _context.IpPoolByName(context.InstanceToValidate?.IpPoolName).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "IpPool does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}