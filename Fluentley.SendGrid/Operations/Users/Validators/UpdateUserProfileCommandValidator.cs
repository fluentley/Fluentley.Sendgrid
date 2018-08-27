using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Users.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Users.Validators
{
    internal class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        private readonly Context _context;

        public UpdateUserProfileCommandValidator(Context context)
        {
            _context = context;
        }
    }
}