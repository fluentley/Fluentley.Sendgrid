using System;
using System.Linq;
using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.SubUsers.Commands;
using Fluentley.SendGrid.Operations.SubUsers.Core;
using Fluentley.SendGrid.Operations.SubUsers.Queries;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.SubUsers.Validators
{
    internal class UpdateSubUserCommandValidator : AbstractValidator<UpdateSubUserCommand>
    {
       
    }
}