using Cosmos.Data.Cerulean.Cloud;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Cerualean.Cloud
{
    public interface ICosmosService {
        Task<IEnumerable<Product>> GetItemsAsync(string queryString);

        Task AddItemAsync(Product item);

        Task<Form?> GetFormAsync(string formId);
    }
}
