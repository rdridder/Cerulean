namespace DTO.Cerulean.Cloud
{
    public class VariationDTO
    {
        public VariationDTO(int id, string sku, string name)
        {
            Id = id;
            Sku = sku;
            Name = name;
        }

        public int Id { get; }

        public string Sku { get; }

        public string Name { get; }
    }
}
