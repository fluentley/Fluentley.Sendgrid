using Fluentley.SendGrid.Operations.Alerts.Commands;
using Fluentley.SendGrid.Operations.Alerts.Models;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Alerts.Validators
{
    internal class CreateAlertCommandValidator : AbstractValidator<CreateAlertCommand>
    {
        public CreateAlertCommandValidator()
        {
            RuleFor(x => x.TypeForAlert).NotEqual(AlertType.Undefined);
            RuleFor(x => x.EmailToForAlert).EmailAddress();
            RuleFor(x => x.PercentageForAlert).GreaterThan(0).When(x => x.PercentageForAlert.HasValue);
            RuleFor(x => x.PercentageForAlert).NotNull().When(x => x.TypeForAlert == AlertType.UsageLimit)
                .WithMessage("Percentage cannot be empty when Alert Type is Usage Limit");
        }
    }
}