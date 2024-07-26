using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Cerulean.Cloud
{
    public class Variation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Sku { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
