using Fluentley.SendGrid.Operations.IpPools.Commands;
using FluentValidation;

namespace Fluentley.SendGrid.Operations.IpPools.Validators
{
    internal class UpdateIpPoolCommandValidator : AbstractValidator<UpdateIpPoolCommand>
    {
       

        public UpdateIpPoolCommandValidator()
        {
          
            RuleFor(x => x.OldName).NotEmpty();
            RuleFor(x => x.NewName).NotEmpty();
        }

      
    }
}