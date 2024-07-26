using Cosmos.Data.Cerulean.Cloud;
using Interfaces.Cerualean.Cloud;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Cosmos.Services.Cerulean.Cloud
{
    public class CosmosService : ICosmosService
    {
        private Container _container;

        private Database _db;

        public CosmosService(CosmosClient dbClient, string databaseName, string containerName)
        {
            _container = dbClient.GetContainer(databaseName, containerName);
            _db = dbClient.GetDatabase(databaseName);
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(string queryString)
        {
            using var query = _container.GetItemQueryIterator<Product>(new QueryDefinition(queryString));
            List<Product> results = new List<Product>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task<Form?> GetFormAsync(string formId)
        {
            using (FeedIterator<Form> setIterator = _db.GetContainer("Forms").GetItemLinqQueryable<Form>()
                     .Where(b => b.FormId == formId)
                     .ToFeedIterator())
            {
                //Asynchronous query execution
                while (setIterator.HasMoreResults)
                {
                    foreach (var item in await setIterator.ReadNextAsync())
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public async Task AddItemAsync(Product item)
        {
            await this._container.CreateItemAsync<Product>(item, new PartitionKey(item.id));
        }
    }
}
