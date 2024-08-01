using Frontend.Cerulean.Cloud.Components.Base;
using Frontend.Cerulean.Cloud.Interfaces;
using Newtonsoft.Json.Linq;

namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationRequired : IFormValidation
    {
        public FormValidationResult Validate(object? input, Dictionary<string, string>? formValidationOptions)
        {
            var message = $"The input is mandatory.";
            if (input == null) {
                return new FormValidationResult(message);
            }
            if (input is string) {
                if (((string)input).Length == 0) {
                    return new FormValidationResult(message);
                }
            }
            if (input is bool)
            {
                if (!(bool)input)
                {
                    return new FormValidationResult(message);
                }
            }
            return new FormValidationResult(null);
        }
    }
}
