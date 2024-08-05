using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Statics;
using Frontend.Cerulean.Cloud.Interfaces;
using Interfaces.Cerualean.Cloud;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Frontend.Cerulean.Cloud.Components.Forms
{
    public partial class FormRenderer
    {
        [Inject]
        private ICosmosService _cosmosService { get; set; } = default!;

        [Inject]
        private IFormValidationRegistry _formValidationRegistry { get; set; } = default!;

        [Parameter, EditorRequired] 
        public required string FormId { get; init; }
        
        public Dictionary<string, object> ElementValues = default!;

        private Form? _form;

        private EditContext? editContext;

        private ValidationMessageStore? messageStore;

        protected override async Task OnInitializedAsync()
        {
            _form = await _cosmosService.GetFormAsync(FormId);
            ElementValues = new Dictionary<string, object>();
            foreach (var section in _form?.Sections ?? [])
            {
                FillDictionary(section);
            }
            editContext = new EditContext(ElementValues);
            messageStore = new ValidationMessageStore(editContext);
            editContext.OnValidationRequested += HandleValidationRequested;
        }

        private void FillDictionary(FormSection formSection) {
            if (formSection.SubSections?.Count > 0)
            {
                foreach (var subSection in formSection.SubSections) {
                    FillDictionary(subSection);
                }
            }
            foreach (var element in formSection.Elements ?? []) {
                var key = FormHelper.GetKeyRepeatableKey(element.Name, formSection.CopyVersion);
                ElementValues[key] = "";
            }
        }

        private void HandleValidSubmit()
        {
            if (true) { }
        }

        private void HandleValidationRequested(object? sender, ValidationRequestedEventArgs args)
        {
            messageStore?.Clear();
            foreach (var formSection in _form.Sections) {
                ValidateForm(formSection);
            }


            //if (UserModel?.PasswordConfirmation != UserModel?.Password)
            //{
            //    MessageStore?.Add(() => UserModel.PasswordConfirmation, "Passwords do not match.");
            //    EditContext?.NotifyValidationStateChanged();
            //}

            //// Custom validation logic
            //if (!Model!.Options)
            //{
            //    messageStore?.Add(() => Model.Options, "Select at least one.");
            //}
        }

        private void ValidateForm(FormSection formSection)
        {
            if (formSection.SubSections?.Count > 0)
            {
                foreach (var subSection in formSection.SubSections)
                {
                    ValidateForm(subSection);
                }
            }
            foreach (var element in formSection.Elements ?? [])
            {
                if (element.Validations != null && element.Validations.Length > 0) {
                    foreach (var validator in element.Validations) {
                        var validatorFromRegistry = _formValidationRegistry.GetValidator(validator.Name);
                        var validationResult = validatorFromRegistry.Validate(ElementValues[element.Name], validator.Options);
                        if (!validationResult.IsValid) {
                            messageStore?.Add(() => element.Name, validationResult.Message ?? "No message set in validation.");
                        }
                    }
                
                }
            }
            editContext?.NotifyValidationStateChanged();
        }

        public void Dispose()
        {
            if (editContext is not null)
            {
                editContext.OnValidationRequested -= HandleValidationRequested;
            }
        }



    }
}
