using Frontend.Cerulean.Cloud.Components.Validations;
using Frontend.Cerulean.Cloud.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Frontend.Cerulean.Cloud.Components.Base
{
    public abstract class BaseFormValidation(IStringLocalizer<App> localizer) : IFormValidation
    {
        protected IStringLocalizer<App> Localizer { get; } = localizer;

        public abstract FormValidationResult Validate(object? input, Dictionary<string, string>? formValidationOptions);
    }
}
