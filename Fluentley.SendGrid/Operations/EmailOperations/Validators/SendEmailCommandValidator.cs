using FluentValidation;

namespace Fluentley.SendGrid.Operations.EmailOperations.Validators
{
    internal class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(x => x.SubjectOfEmail).NotEmpty();
        }
    }
}