using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class DenyTeammateAccessRequestCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DenyTeammateAccessRequestCommandValidator(Context context)
        {
            _context = context;
        }
    }
}