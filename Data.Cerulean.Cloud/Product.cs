using System.ComponentModel.DataAnnotations;

namespace Data.Cerulean.Cloud
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string? Sku { get; set; }

        [Required]
        [StringLength(256)]
        public string? Name { get; set; }

        public List<Variation> Variations { get; set; }

    }
}
