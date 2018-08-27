using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class DeleteTeammateCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeleteTeammateCommandValidator(Context context)
        {
            _context = context;
        }
    }
}