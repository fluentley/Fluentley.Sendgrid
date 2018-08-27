using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Validators
{
    internal class AuthenticateToDomainCommandValidator : AbstractValidator<AuthenticateToDomainCommand>
    {
        private readonly Context _context;

        public AuthenticateToDomainCommandValidator(Context context)
        {
            _context = context;
        }
    }
}