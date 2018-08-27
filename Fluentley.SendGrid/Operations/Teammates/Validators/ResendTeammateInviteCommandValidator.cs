using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class ResendTeammateInviteCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public ResendTeammateInviteCommandValidator(Context context)
        {
            _context = context;
        }
    }
}