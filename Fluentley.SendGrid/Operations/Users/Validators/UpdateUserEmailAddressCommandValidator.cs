using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Users.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Users.Validators
{
    internal class UpdateUserEmailAddressCommandValidator : AbstractValidator<UpdateUserEmailAddressCommand>
    {
        private readonly Context _context;

        public UpdateUserEmailAddressCommandValidator(Context context)
        {
            _context = context;
        }
    }
}