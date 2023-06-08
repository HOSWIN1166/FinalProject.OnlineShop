using Microsoft.EntityFrameworkCore;
using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;
using System.Reflection;

namespace OnlineShop.Saas.Monolithic.Models
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category>Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
