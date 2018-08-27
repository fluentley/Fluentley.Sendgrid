using System;

namespace Fluentley.SendGrid.Operations.EmailOperations.Core
{
    public interface IRecipientOption
    {
        IRecipientOption AddTo(string emailAddress, string name = null);
        IRecipientOption AddCc(string emailAddress, string name = null);
        IRecipientOption AddBcc(string emailAddress, string name = null);
        IRecipientOption Subject(string subject);
        IRecipientOption AddSubstitution(string key, string value);
        IRecipientOption AddCustomArguments(string key, string value);
        IRecipientOption SendAtUtc(DateTime sendTimeSpan);
        IRecipientOption AddHeader(string key, string value);
    }
}