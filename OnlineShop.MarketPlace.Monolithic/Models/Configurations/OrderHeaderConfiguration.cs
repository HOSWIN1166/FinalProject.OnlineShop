using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.MarketPlace.Monolithic.Models.DomainModels.OrderAggregates;

namespace OnlineShop.MarketPlace.Monolithic.Models.Configurations
{
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            //builder.Property(p => p.FName).IsRequired().HasMaxLength(50);
            //builder.Property(p => p.LName).IsRequired().HasMaxLength(50);.Totable("Order""")
            builder.Property(orderHeader => orderHeader.Code).IsRequired();
            builder.Property(orderHeader => orderHeader.Date).HasDefaultValue(DateTime.Now);
            builder.Property(orderHeader => orderHeader.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderHeader => orderHeader.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(orderHeader => orderHeader.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
