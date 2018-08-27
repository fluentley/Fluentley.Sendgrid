using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Validators
{
    internal class
        RemoveIpAddressFromAuthenticatedDomainCommandValidator : AbstractValidator<
            RemoveIpAddressFromAuthenticatedDomainCommand>
    {
        private readonly Context _context;

        public RemoveIpAddressFromAuthenticatedDomainCommandValidator(Context context)
        {
            _context = context;
        }
    }
}