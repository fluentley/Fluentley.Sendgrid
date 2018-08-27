using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Validators
{
    internal class DisassociateBrandedForSubUserCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public DisassociateBrandedForSubUserCommandValidator(Context context)
        {
            _context = context;
        }
    }
}