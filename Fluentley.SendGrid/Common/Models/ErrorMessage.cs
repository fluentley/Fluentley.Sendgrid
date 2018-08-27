using System.Collections.Generic;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Fluentley.SendGrid.Common.Models
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {
        }

        public ErrorMessage(ErrorType type, string message, string field = "", string help = "")
        {
            Message = message;
            Field = field;
            Help = help;
            ErrorType = type;
        }

        public ErrorMessage(ErrorType type, params ErrorMessage[] messages)
        {
            foreach (var message in messages)
            {
                Message = message.Message;
                Field = message.Field;
                Help = message.Help;
                ErrorType = type;
            }
        }

        public ErrorMessage(ErrorType type, IList<ValidationFailure> messages)
        {
            foreach (var message in messages)
            {
                Message = message.ErrorMessage;
                Field = message.PropertyName;

                ErrorType = type;
            }
        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("help")]
        public string Help { get; set; }

        public ErrorType ErrorType { get; set; }
    }
}