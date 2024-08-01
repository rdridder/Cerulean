using Frontend.Cerulean.Cloud.Components.Base;
using Frontend.Cerulean.Cloud.Interfaces;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;

namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationRequired : BaseFormValidation
    {
        public FormValidationRequired(IStringLocalizer<App> localizer) : base(localizer)
        {
        }

        public override FormValidationResult Validate(object? input, Dictionary<string, string>? formValidationOptions)
        {
            var message = Localizer["FormValidationRequired"];
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
