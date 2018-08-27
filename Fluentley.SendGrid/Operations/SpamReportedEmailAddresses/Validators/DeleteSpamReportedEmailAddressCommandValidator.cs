using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.SpamReportedEmailAddresses.Validators
{
    internal class
        DeleteSpamReportedEmailAddressCommandValidator : AbstractValidator<DeleteSpamReportedEmailAddressCommand>
    {
        private readonly Context _context;

        public DeleteSpamReportedEmailAddressCommandValidator(Context context)
        {
            _context = context;
        }
    }
}