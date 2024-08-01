using Frontend.Cerulean.Cloud.Components.Base;
using Frontend.Cerulean.Cloud.Components.Exceptions;
using Frontend.Cerulean.Cloud.Interfaces;
using Microsoft.Extensions.Localization;

namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationMaxLength : BaseFormValidation
    {
        public FormValidationMaxLength(IStringLocalizer<App> localizer) : base(localizer)
        {
        }

        public override FormValidationResult Validate(object? input, Dictionary<string, string>? formValidationOptions) {
            if (input is not string) {
                return new FormValidationResult(null);
            }
            
            if (formValidationOptions == null) {
                throw new FormValidationConfigurationException(Localizer["MaxLengthOptionMissing"]);
            }

            // TODO fix magic number
            int MaxLengthOfValue = int.Parse(formValidationOptions["MaxLength"]);

            if (input != null && ((string)input).Length > MaxLengthOfValue) {
                return new FormValidationResult(Localizer["MaxLengthExceeded", MaxLengthOfValue]);
            }
            return new FormValidationResult(null);
        }
    }
}
