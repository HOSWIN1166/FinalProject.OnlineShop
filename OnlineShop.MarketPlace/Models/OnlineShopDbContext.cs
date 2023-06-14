using Microsoft.EntityFrameworkCore;
using OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate;
using System.Reflection;

namespace OnlineShop.MarketPlace.Models
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<OrderHeader> OrderHeader { get; set; }
        // public DbSet<OrderDetail> OrderDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        // public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate.OrderDetail> OrderDetail { get; set; } = default!;
    }
}
