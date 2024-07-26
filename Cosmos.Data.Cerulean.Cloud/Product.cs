using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Data.Cerulean.Cloud
{
    public class Product
    {
        public Product(string id, string sku, string name)
        {
            this.id = id;
            Sku = sku;
            Name = name;
        }

        public string id { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public List<ProductAttribute> Attributes { get; set; }

        public List<Tag> Tags { get; set; }

        public List<Image> Images { get; set; }

    }
}
