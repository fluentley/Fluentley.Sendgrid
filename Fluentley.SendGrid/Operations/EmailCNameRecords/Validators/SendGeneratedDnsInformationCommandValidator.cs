using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.EmailCNameRecords.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.EmailCNameRecords.Validators
{
    internal class SendGeneratedDnsInformationCommandValidator : AbstractValidator<SendGeneratedDnsInformationCommand>
    {
        private readonly Context _context;

        public SendGeneratedDnsInformationCommandValidator(Context context)
        {
            _context = context;
        }
    }
}