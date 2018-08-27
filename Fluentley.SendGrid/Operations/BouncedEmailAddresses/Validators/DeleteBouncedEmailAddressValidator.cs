using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.BouncedEmailAddresses.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.BouncedEmailAddresses.Validators
{
    internal class DeleteBouncedEmailAddressCommandValidator : AbstractValidator<DeleteBouncedEmailAddressCommand>
    {
        private readonly Context _context;

        public DeleteBouncedEmailAddressCommandValidator(Context context)
        {
            _context = context;
        }
    }
}