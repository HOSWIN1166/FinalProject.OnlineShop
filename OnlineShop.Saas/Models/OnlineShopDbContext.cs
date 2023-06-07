using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Models.DomainModels.PersonAggregates;
using OnlineShop.Saas.Models.DomainModels.ProductAggregates;
using System.Reflection;

namespace OnlineShop.Saas.Models
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<DomainModels.PersonAggregates.Category> CategoryPerson { get; set; }
        public DbSet<DomainModels.ProductAggregates.Category> CategoryProduct { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
