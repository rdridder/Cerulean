using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Base;
using Frontend.Cerulean.Cloud.Components.Exceptions;
using Frontend.Cerulean.Cloud.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationRegistry : IFormValidationRegistry
    {
        private IStringLocalizer<App> _localizer { get; }

        public FormValidationRegistry(IStringLocalizer<App> localizer) {
            _localizer = localizer;
            Validations = new Dictionary<string, IFormValidation>();
            Validations["Required"] = new FormValidationRequired(_localizer);
            Validations["MaxLength"] = new FormValidationMaxLength(_localizer);
        }

        public Dictionary<string, IFormValidation> Validations { get; init; }

        public IFormValidation GetValidator(string key) {
            if (!Validations.TryGetValue(key, out var validator)) {
                throw new FormValidationConfigurationException(_localizer["FormValidationRegistry", key]);
            }
            return validator;
        }
    }
}
