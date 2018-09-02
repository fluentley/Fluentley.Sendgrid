using Fluentley.SendGrid.Operations.ApiKeys.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.ApiKeys.Validators
{
    internal class CreateApiKeyCommandValidator : AbstractValidator<CreateApiKeyCommand>
    {
        public CreateApiKeyCommandValidator()
        {
            RuleFor(x => x.NameOfApiKey).NotNull().NotEmpty();
        }
    }
}