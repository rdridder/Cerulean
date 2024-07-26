using Data.Cerulean.Cloud;
using Data.Cerulean.Cloud.Context;

namespace API.Cerulean.Cloud.Mutations
{
    public partial class Mutation
    {
        public async Task<AddProductPayload> AddProductAsync(
            AddProductInput input, [Service] ProductDbContext context)
        {
            var product = new Product()
            {
                Name = input.Name,
                Sku = input.Sku
            };

            context.Products.Add(product);
            await context.SaveChangesAsync();
            return new AddProductPayload(product);
        }
    }
}
