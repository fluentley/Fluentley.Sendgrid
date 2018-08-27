using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.Teammates.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class InviteTeammateCommandValidator : AbstractValidator<InviteTeammateCommand>
    {
        private readonly Context _context;

        public InviteTeammateCommandValidator(Context context)
        {
            _context = context;
        }
    }
}