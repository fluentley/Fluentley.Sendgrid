using Fluentley.SendGrid.Operations.LinkBrandings.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Validators
{
    internal class UpdateBrandedLinkCommandValidator : AbstractValidator<UpdateBrandedLinkCommand>
    {
        public UpdateBrandedLinkCommandValidator()
        {
            RuleFor(x => x.IsDefaultForBrandedLink).NotNull();
        }
    }
}