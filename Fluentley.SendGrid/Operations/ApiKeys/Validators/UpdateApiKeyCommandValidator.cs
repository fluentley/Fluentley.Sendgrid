using Fluentley.SendGrid.Operations.ApiKeys.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.ApiKeys.Validators
{
    internal class UpdateApiKeyCommandValidator : AbstractValidator<UpdateApiKeyCommand>
    {
        public UpdateApiKeyCommandValidator()
        {
            RuleFor(x => x.ApiKeyId).NotEmpty();
        }
    }
}