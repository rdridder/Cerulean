using Cosmos.Data.Cerulean.Cloud;
using Interfaces.Cerualean.Cloud;
using Microsoft.AspNetCore.Components;

namespace Frontend.Cerulean.Cloud.Pages.Admin
{
    public partial class ProductForm
    {
        [Inject]
        private ICosmosService _cosmosService { get; set; }

        private Form? _form;

        protected override async Task OnInitializedAsync()
        {
            _form = await _cosmosService.GetFormAsync("ProductForm");
        }

    }
}
