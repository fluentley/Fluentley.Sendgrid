using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Validators
{
    internal class
        AddIpAddressToAuthenticatedDomainCommandValidator : AbstractValidator<AddIpAddressToAuthenticatedDomainCommand>
    {
        private readonly Context _context;

        public AddIpAddressToAuthenticatedDomainCommandValidator(Context context)
        {
            _context = context;
        }
    }
}