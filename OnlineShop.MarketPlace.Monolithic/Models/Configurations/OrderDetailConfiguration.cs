using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            //builder.ToTable("OrderDetail", "Order");
            //builder.HasKey(od => new { od.OrderHeaderId , od.ProductId });
            builder.HasKey(orderDetail => new { orderDetail.ProductId, orderDetail.OrderHeaderId });
            builder.Property(orderDetail => orderDetail.Quantity).IsRequired();
            builder.Property(orderDetail => orderDetail.UnitPrice).IsRequired();
            builder.Property(orderDetail => orderDetail.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderDetail => orderDetail.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderDetail => orderDetail.IsDelete).IsRequired().HasDefaultValue(false);
        } 
    }
}
