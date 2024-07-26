using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Cerulean.Cloud.Context;

namespace Data.Cerulean.Cloud.Factory
{
    internal class ContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<ProductDbContext>();
            dbContextBuilder.UseSqlite("Data Source=products.db");
            return new ProductDbContext(dbContextBuilder.Options);
        }
    }
}
