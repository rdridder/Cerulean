using Cosmos.Data.Cerulean.Cloud;
using Interfaces.Cerualean.Cloud;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Frontend.Cerulean.Cloud.Pages.Admin
{
    public partial class FormBuilder
    {
        [Inject]
        private ICosmosService _cosmosService { get; set; }

        private Form? _form;

        private EditContext? editContext;

        private ValidationMessageStore? messageStore;

        protected override async Task OnInitializedAsync()
        {
            _form = await _cosmosService.GetFormAsync("ProductForm");
        }


    }
}
