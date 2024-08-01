using Frontend.Cerulean.Cloud.Components.Base;
using Frontend.Cerulean.Cloud.Components.Exceptions;
using Frontend.Cerulean.Cloud.Interfaces;

namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationMaxLength : IFormValidation
    {
        public FormValidationResult Validate(object? input, Dictionary<string, string>? formValidationOptions) {
            if (input is not string) {
                return new FormValidationResult(null);
            }
            
            if (formValidationOptions == null) {
                throw new FormValidationConfigurationException("The FormValidationMaxLength validation needs an option with MaxLength set.");
            }

            // TODO fix magic number
            int MaxLengthOfValue = int.Parse(formValidationOptions["MaxLength"]);

            if (input != null && ((string)input).Length > MaxLengthOfValue) {
                // TODO message needs to be translatable
                return new FormValidationResult($"The input exceeds {MaxLengthOfValue} characters.");
            }
            return new FormValidationResult(null);
        }
    }
}
