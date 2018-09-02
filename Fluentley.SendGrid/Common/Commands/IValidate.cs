using FluentValidation.Results;
using System.Threading.Tasks;

namespace Fluentley.SendGrid.Common.Commands
{
    public interface IValidate
    {
       Task<ValidationResult> Validate();
    }
}
