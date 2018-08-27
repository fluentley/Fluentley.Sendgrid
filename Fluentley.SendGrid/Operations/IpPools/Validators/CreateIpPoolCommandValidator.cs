using Fluentley.SendGrid.Operations.IpPools.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.IpPools.Validators
{
    internal class CreateIpPoolCommandValidator : AbstractValidator<CreateIpPoolCommand>
    {
        public CreateIpPoolCommandValidator()
        {
            RuleFor(x => x.NameOfThePool).NotEmpty();
        }
    }
}