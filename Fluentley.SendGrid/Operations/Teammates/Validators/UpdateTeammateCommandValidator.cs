using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class UpdateTeammateCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public UpdateTeammateCommandValidator(Context context)
        {
            _context = context;
        }
    }
}