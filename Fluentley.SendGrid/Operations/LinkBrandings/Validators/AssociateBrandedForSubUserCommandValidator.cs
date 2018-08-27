using Fluentley.SendGrid.Contexts;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.LinkBrandings.Validators
{
    internal class AssociateBrandedForSubUserCommandValidator : AbstractValidator<string>
    {
        private readonly Context _context;

        public AssociateBrandedForSubUserCommandValidator(Context context)
        {
            _context = context;
        }
    }
}