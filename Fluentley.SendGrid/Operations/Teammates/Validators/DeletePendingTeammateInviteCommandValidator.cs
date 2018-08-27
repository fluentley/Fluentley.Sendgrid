using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class DeletePendingTeammateInviteCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DeletePendingTeammateInviteCommandValidator(Context context)
        {
            _context = context;
        }
    }
}