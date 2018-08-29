using Fluentley.SendGrid.Operations.Alerts.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Alerts.Validators
{
    internal class UpdateAlertCommandValidator : AbstractValidator<UpdateAlertCommand>
    {
        public UpdateAlertCommandValidator()
        {
            RuleFor(x => x.IdForAlert).NotEmpty();
            RuleFor(x => x.PercentageForAlert).GreaterThan(0).When(x => x.PercentageForAlert.HasValue);
        }
    }
}