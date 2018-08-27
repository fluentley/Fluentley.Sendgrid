using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Webhooks.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Webhooks.Validators
{
    internal class SendTestWebhookEventCommandValidator : AbstractValidator<SendTestWebhookEventCommand>
    {
        private readonly Context _context;

        public SendTestWebhookEventCommandValidator(Context context)
        {
            _context = context;
        }
    }
}