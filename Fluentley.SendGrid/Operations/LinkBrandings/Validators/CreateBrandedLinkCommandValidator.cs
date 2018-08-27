using Fluentley.SendGrid.Operations.LinkBrandings.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Validators
{
    internal class CreateBrandedLinkCommandValidator : AbstractValidator<CreateBrandedLinkCommand>
    {
        public CreateBrandedLinkCommandValidator()
        {
            RuleFor(x => x.DomainUrlOfBrandedLink).NotEmpty();
        }
    }
}