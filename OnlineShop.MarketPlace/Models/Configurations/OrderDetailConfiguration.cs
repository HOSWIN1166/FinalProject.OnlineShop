using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.MarketPlace.Models.DomainModels.OrderAggregate;

namespace OnlineShop.MarketPlace.Models.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail", "Order");
            builder.HasKey(od => new
            {
                od.OrderHeaderId,
                od.ProductId,
            });
        }
    }
}
