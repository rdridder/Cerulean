using Frontend.Cerulean.Cloud.Components.Validations;

namespace Frontend.Cerulean.Cloud.Interfaces
{
    public interface IFormValidation
    {
        FormValidationResult Validate(object? input, Dictionary<string, string>? formValidationOptions);

    }
}
