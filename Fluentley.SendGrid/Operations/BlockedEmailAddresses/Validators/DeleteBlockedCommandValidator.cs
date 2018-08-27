using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Validators
{
    internal class DeleteBlockedEmailAddressCommandValidator : AbstractValidator<DeleteBlockedEmailAddressCommand>
    {
        private readonly Context _context;

        public DeleteBlockedEmailAddressCommandValidator(Context context)
        {
            _context = context;
        }
    }
}