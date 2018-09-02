using Fluentley.SendGrid.Operations.BlockedEmailAddresses.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.BlockedEmailAddresses.Validators
{
    internal class DeleteBlockedEmailAddressCommandValidator : AbstractValidator<DeleteBlockedEmailAddressCommand>
    {
      

        public DeleteBlockedEmailAddressCommandValidator()
        {
           
        }
    }
}