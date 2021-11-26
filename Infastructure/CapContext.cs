using Domain;
using Infastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Infastructure
{
    public class CapContext : IdentityDbContext<ApplicationUser>
    {
        private DbContextOptions<CapContext> options;

        public DbSet<CapWeek> CapWeek { get; set; }

        public CapContext(DbContextOptions<CapContext> options)
         : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        internal static CapContext CreateContext()
        {
            return new CapContext(new DbContextOptionsBuilder<CapContext>().UseSqlServer(
                 new ConfigurationBuilder()
                     .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.json"))
                     .AddEnvironmentVariables()
                     .Build()
                     .GetConnectionString("DefaultConnection")
                 ).Options);
        }
    }
}
