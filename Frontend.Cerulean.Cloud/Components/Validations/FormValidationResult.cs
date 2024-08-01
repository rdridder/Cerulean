namespace Frontend.Cerulean.Cloud.Components.Validations
{
    public class FormValidationResult
    {
        public FormValidationResult(string? errorMessage) { 
            Message = errorMessage;
            if (errorMessage == null) {
                IsValid = true;
            }
        }

        public string? Message { get; }

        public bool IsValid { get; }
    }
}
