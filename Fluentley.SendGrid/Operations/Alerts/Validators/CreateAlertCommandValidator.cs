using Fluentley.SendGrid.Operations.Alerts.Commands;
using Fluentley.SendGrid.Operations.Alerts.Models;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Alerts.Validators
{
    internal class CreateAlertCommandValidator : AbstractValidator<CreateAlertCommand>
    {
        public CreateAlertCommandValidator()
        {
            RuleFor(x => x.Type).NotEqual(AlertType.Undefined);
            RuleFor(x => x.EmailTo).NotEmpty();
            RuleFor(x => x.Percentage).GreaterThan(0).When(x => x.Percentage.HasValue);
            RuleFor(x => x.Percentage).NotNull().When(x => x.Type == AlertType.UsageLimit)
                .WithMessage("Percentage cannot be empty when Alert Type is Usage Limit");
        }
    }
}