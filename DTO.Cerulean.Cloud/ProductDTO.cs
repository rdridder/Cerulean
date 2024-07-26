namespace DTO.Cerulean.Cloud
{
    public class ProductDTO
    {
        public ProductDTO(int id, string sku, string name, List<VariationDTO> variations)
        {
            Id = id;
            Sku = sku;
            Name = name;
            Variations = variations;
        }

        public int Id { get; }

        public string Sku { get; }

        public string Name { get; }

        public List<VariationDTO> Variations { get; }

    }
}
