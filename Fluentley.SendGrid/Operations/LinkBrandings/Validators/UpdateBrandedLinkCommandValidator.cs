using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.LinkBrandings.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Validators
{
    internal class UpdateBrandedLinkCommandValidator : AbstractValidator<UpdateBrandedLinkCommand>
    {
        private readonly Context _context;

        public UpdateBrandedLinkCommandValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.IsDefaultForBrandedLink).NotNull();
        }

        protected override bool PreValidate(ValidationContext<UpdateBrandedLinkCommand> context,
            ValidationResult result)
        {
            var findResult = _context.BrandedLinkById(context.InstanceToValidate?.Id).Result;

            if (findResult.GetContent() == null)
            {
                result.Errors.Add(new ValidationFailure("", "BrandedLink does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}