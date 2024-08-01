using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Base;
using Frontend.Cerulean.Cloud.Components.Exceptions;
using Frontend.Cerulean.Cloud.Interfaces;

namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationRegistry : IFormValidationRegistry
    {   
        public FormValidationRegistry() {
            Validations = new Dictionary<string, IFormValidation>();
            Validations["Required"] = new FormValidationRequired();
            Validations["MaxLength"] = new FormValidationMaxLength();
        }

        public Dictionary<string, IFormValidation> Validations { get; init; }

        public IFormValidation GetValidator(string key) {
            if (!Validations.TryGetValue(key, out var validator)) {
                throw new FormValidationConfigurationException($"No validator in registry for key: {key}");
            }
            return validator;
        }
    }
}
