using Cosmos.Data.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Statics;
using Interfaces.Cerualean.Cloud;
using Microsoft.AspNetCore.Components;

namespace Frontend.Cerulean.Cloud.Components.Forms
{
    public partial class FormRenderer
    {
        [Inject]
        private ICosmosService _cosmosService { get; set; } = default!;

        [Parameter, EditorRequired] 
        public required string FormId { get; init; }
        
        public Dictionary<string, object> ElementValues = default!;

        private Form? _form;
        protected override async Task OnInitializedAsync()
        {
            _form = await _cosmosService.GetFormAsync(FormId);
            ElementValues = new Dictionary<string, object>();
            foreach (var section in _form?.Sections ?? [])
            {
                FillDictionary(section);
            }
        }

        private void FillDictionary(FormSection formSection) {
            if (formSection.SubSection != null)
            {
                FillDictionary(formSection.SubSection);
            }
            foreach (var element in formSection.Elements ?? []) {
                var key = FormHelper.GetKeyRepeatableKey(formSection.IsRepeatable, element.Name);
                ElementValues[key] = "";
            }
        }

        private void HandleValidSubmit()
        {
            if (true) { }
        }


    }
}
