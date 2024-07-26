using DTO.Cerulean.Cloud;

namespace API.Cerulean.Cloud.Queries
{
    public partial class Query
    {
        public ProductDTO GetProduct() =>
            new ProductDTO(1, "abc-12", "Test", new List<VariationDTO>() {
                    new VariationDTO(1, "abc-12-1", "Variation 1"),
                    new VariationDTO(2, "abc-12-2", "Variation 2")
                });
    }
}
