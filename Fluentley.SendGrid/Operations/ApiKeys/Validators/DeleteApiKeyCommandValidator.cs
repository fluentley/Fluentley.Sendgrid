using Fluentley.SendGrid.Operations.ApiKeys.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.ApiKeys.Validators
{
    internal class DeleteApiKeyCommandValidator : AbstractValidator<DeleteApiKeyCommand>
    {
        public DeleteApiKeyCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}