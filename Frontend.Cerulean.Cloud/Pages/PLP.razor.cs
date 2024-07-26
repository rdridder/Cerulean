using Cosmos.Data.Cerulean.Cloud;
using Interfaces.Cerualean.Cloud;
using Microsoft.AspNetCore.Components;

namespace Frontend.Cerulean.Cloud.Pages
{
    public partial class PLP
    {
        [Inject]
        private ICosmosService _cosmosService { get; set; }

        private IEnumerable<Product>? products;

        protected override async Task OnInitializedAsync()
        {
            products = await _cosmosService.GetItemsAsync("SELECT * FROM c");
        }
    }
}
