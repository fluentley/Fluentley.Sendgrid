using Fluentley.SendGrid.Operations.Alerts.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Alerts.Validators
{
    internal class DeleteAlertCommandValidator : AbstractValidator<DeleteAlertCommand>
    {
        public DeleteAlertCommandValidator()
        {
            RuleFor(x => x.IdForAlert).NotEmpty();
        }
    }
}