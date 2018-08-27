using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Validators
{
    internal class
        AssociateSubuserToAuthenticatedDomainCommandValidator : AbstractValidator<
            AssociateSubuserToAuthenticatedDomainCommand>
    {
        private readonly Context _context;

        public AssociateSubuserToAuthenticatedDomainCommandValidator(Context context)
        {
            _context = context;
        }
    }
}