using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.InvalidEmailAddresses.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.InvalidEmailAddresses.Validators
{
    internal class DeleteInvalidEmailAddressCommandValidator : AbstractValidator<DeleteInvalidEmailAddressCommand>
    {
        private readonly Context _context;

        public DeleteInvalidEmailAddressCommandValidator(Context context)
        {
            _context = context;
        }
    }
}