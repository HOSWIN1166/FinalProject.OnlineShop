using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate;

namespace OnlineShop.MarketPlace.Models.Configurations
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable("OrderHeader", "Order");
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.FName).IsRequired().HasMaxLength(50);
            //builder.Property(p => p.LName).IsRequired().HasMaxLength(50);.Totable("Order""")
        }
    }
}
