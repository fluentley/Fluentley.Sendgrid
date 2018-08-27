using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.DomainAuthentications.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.DomainAuthentications.Validators
{
    internal class
        UpdateAuthenticatedDomainSettingCommandValidator : AbstractValidator<UpdateAuthenticatedDomainSettingCommand>
    {
        private readonly Context _context;

        public UpdateAuthenticatedDomainSettingCommandValidator(Context context)
        {
            _context = context;
        }
    }
}