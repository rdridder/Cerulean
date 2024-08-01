namespace Frontend.Cerulean.Cloud.Interfaces
{
    public interface IFormValidationRegistry
    {
        IFormValidation GetValidator(string key);
    }
}
