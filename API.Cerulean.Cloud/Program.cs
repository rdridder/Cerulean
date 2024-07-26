using API.Cerulean.Cloud.Mutations;
using API.Cerulean.Cloud.Queries;
using Data.Cerulean.Cloud.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Cerulean.Cloud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlite("Data Source=../Data.Cerulean.Cloud/products.db"));


            var app = builder.Build();
            app.MapGraphQL();

            app.Run();
        }
    }
}
