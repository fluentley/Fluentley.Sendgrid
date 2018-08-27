using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.Teammates.Validators
{
    internal class ApproveTeammateAccessRequestCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public ApproveTeammateAccessRequestCommandValidator(Context context)
        {
            _context = context;
        }
    }
}