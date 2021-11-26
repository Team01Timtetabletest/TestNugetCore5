using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.ContextFactories
{
    public class CapTimeTableContextFactory : IDesignTimeDbContextFactory<CapContext>
    {
        public CapContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CapContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var migrationAssembly = typeof(CapTimeTableContextFactory).GetTypeInfo().Assembly.GetName().Name;
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssembly));

            return new CapContext(builder.Options);
        }
    }
}