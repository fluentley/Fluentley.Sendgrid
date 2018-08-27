using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Users.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Users.Validators
{
    internal class UpdateUserNameCommandValidator : AbstractValidator<UpdateUserNameCommand>
    {
        private readonly Context _context;

        public UpdateUserNameCommandValidator(Context context)
        {
            _context = context;
        }
    }
}