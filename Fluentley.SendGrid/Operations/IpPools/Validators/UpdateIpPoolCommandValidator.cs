using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.IpPools.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.IpPools.Validators
{
    internal class UpdateIpPoolCommandValidator : AbstractValidator<UpdateIpPoolCommand>
    {
        private readonly Context _context;

        public UpdateIpPoolCommandValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.OldName).NotEmpty();
            RuleFor(x => x.NewName).NotEmpty();
        }

        protected override bool PreValidate(ValidationContext<UpdateIpPoolCommand> context, ValidationResult result)
        {
            var findResult = _context.IpPoolByName(context.InstanceToValidate?.OldName).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "IpPool does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}