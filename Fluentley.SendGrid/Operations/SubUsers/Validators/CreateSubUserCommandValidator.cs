using Fluentley.SendGrid.Operations.SubUsers.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.SubUsers.Validators
{
    internal class CreateSubUserCommandValidator : AbstractValidator<CreateSubUserCommand>
    {
        public CreateSubUserCommandValidator()
        {
            RuleFor(x => x.SubUserUserName).NotEmpty();
            RuleFor(x => x.SubUserEmailAddress).NotEmpty().EmailAddress();
            RuleFor(x => x.SubUserPassword).NotEmpty();
            RuleFor(x => x.SubUserIps).Must(x => x.Count > 1).WithMessage("Please at least assign 1 ip address");
        }
    }
}