using Data.Cerulean.Cloud;

namespace API.Cerulean.Cloud.Mutations
{
    public class AddProductPayload
    {
        public AddProductPayload(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}
