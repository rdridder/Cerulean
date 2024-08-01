using Cosmos.Services.Cerulean.Cloud;
using Frontend.Cerulean.Cloud.Components.Validations;
using Frontend.Cerulean.Cloud.Interfaces;
using Interfaces.Cerualean.Cloud;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Configuration;

namespace Frontend.Cerulean.Cloud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;

            var databaseName = builder.Configuration.GetValue<string>("CosmosDb:DatabaseName");
            var containerName = builder.Configuration.GetValue<string>("CosmosDb:ContainerName");
            var account = builder.Configuration.GetValue<string>("CosmosDb:Account");
            var key = builder.Configuration.GetValue<string>("CosmosDb:Key");


            builder.Services.AddSingleton<ICosmosService>(InitializeCosmosClientInstanceAsync(databaseName,containerName,account,key).GetAwaiter().GetResult());
            builder.Services.AddSingleton<IFormValidationRegistry, FormValidationRegistry>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }

            // <InitializeCosmosClientInstanceAsync>
    /// <summary>
    /// Creates a Cosmos DB database and a container with the specified partition key. 
    /// </summary>
    /// <returns></returns>
    private static async Task<CosmosService> InitializeCosmosClientInstanceAsync(string databaseName, string containerName, string account, string key)
    {
        // If key is not set, assume we're using managed identity
        //string key = configurationSection.GetSection("Key").Value;
        //ManagedIdentityCredential miCredential;
        Microsoft.Azure.Cosmos.CosmosClient client;
        if (string.IsNullOrEmpty(key))
        {
            //miCredential = new ManagedIdentityCredential();
            //client = new Microsoft.Azure.Cosmos.CosmosClient(account, miCredential);
        }
        else
        {
            //client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
        }

        client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);

        CosmosService cosmosDbService = new CosmosService(client, databaseName, containerName);
        Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        await database.Database.CreateContainerIfNotExistsAsync(containerName, "/Sku");

        return cosmosDbService;
    }
    }
}
