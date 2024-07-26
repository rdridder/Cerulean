using Data.Cerulean.Cloud;
using Data.Cerulean.Cloud.Context;
using DTO.Cerulean.Cloud;

namespace API.Cerulean.Cloud.Queries
{
    public partial class Query
    {
        public IQueryable<Product> GetProductsFromDb([Service] ProductDbContext context) =>
            context.Products;
    }
}
