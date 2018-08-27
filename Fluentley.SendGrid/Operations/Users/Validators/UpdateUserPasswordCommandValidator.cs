using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Users.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Users.Validators
{
    internal class UpdateUserPasswordCommandValidator : AbstractValidator<UpdateUserPasswordCommand>
    {
        private readonly Context _context;

        public UpdateUserPasswordCommandValidator(Context context)
        {
            _context = context;
        }
    }
}