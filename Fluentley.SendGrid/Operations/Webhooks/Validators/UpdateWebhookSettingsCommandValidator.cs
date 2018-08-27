using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Webhooks.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Webhooks.Validators
{
    internal class UpdateWebhookSettingsCommandValidator : AbstractValidator<UpdateWebHookSettingsCommand>
    {
        private readonly Context _context;

        public UpdateWebhookSettingsCommandValidator(Context context)
        {
            _context = context;
        }
    }
}