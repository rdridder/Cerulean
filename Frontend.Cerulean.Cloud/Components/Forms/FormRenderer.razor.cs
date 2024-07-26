using Cosmos.Data.Cerulean.Cloud;
using Interfaces.Cerualean.Cloud;
using Microsoft.AspNetCore.Components;

namespace Frontend.Cerulean.Cloud.Components.Forms
{
    public partial class FormRenderer
    {
        [Inject]
        private ICosmosService? _cosmosService { get; set; }

        [Parameter] 
        public string? FormId { get; set; }
        
        public Dictionary<string, object> ElementValues = new Dictionary<string, object>();

        private Form? _form;

        protected override async Task OnInitializedAsync()
        {
            _form = await _cosmosService.GetFormAsync(FormId);
            ElementValues = new Dictionary<string, object>();
            foreach (var element in _form.Elements)
            {
                ElementValues[element.Name] = "";
            }
        }

        private void HandleValidSubmit()
        {
            if (true) { }
        }


    }
}
