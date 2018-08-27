using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Alerts.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Alerts.Validators
{
    internal class UpdateAlertCommandValidator : AbstractValidator<UpdateAlertCommand>
    {
        private readonly Context _context;

        public UpdateAlertCommandValidator(Context context)
        {
            _context = context;
            RuleFor(x => x.Percentage).GreaterThan(0).When(x => x.Percentage.HasValue);
        }
    }
}