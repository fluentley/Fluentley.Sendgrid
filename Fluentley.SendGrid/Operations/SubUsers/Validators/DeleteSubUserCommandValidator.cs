using System;
using System.Linq;
using Fluentley.SendGrid.Contexts;
using Fluentley.SendGrid.Operations.SubUsers.Queries;
using FluentValidation;
using FluentValidation.Results;

namespace Fluentley.SendGrid.Operations.SubUsers.Validators
{
    internal class DeleteSubUserCommandValidator : AbstractValidator<Action<ISubUserListQuery>>
    {
        private readonly Context _context;
        private readonly SubUserListQuery _subUserListQuery;

        public DeleteSubUserCommandValidator(string defaultKey, Context context)
        {
            _context = context;

            _subUserListQuery = new SubUserListQuery(defaultKey);
        }

        protected override bool PreValidate(ValidationContext<Action<ISubUserListQuery>> context,
            ValidationResult result)
        {
            context.InstanceToValidate(_subUserListQuery);
            var subUserListResult = _context.SubUsers(_subUserListQuery).Result;

            if (!subUserListResult.ResponseMessage.IsSuccessStatusCode || !subUserListResult.GetContent().Any())
            {
                result.Errors.Add(new ValidationFailure("", "SubUser does not exists anymore"));
                return false;
            }

            return true;
        }
    }
}