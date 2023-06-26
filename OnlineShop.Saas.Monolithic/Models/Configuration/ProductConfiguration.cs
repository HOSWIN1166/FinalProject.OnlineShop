using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Saas.Monolithic.Models.DomainModels.ProductAggregates;

namespace OnlineShop.Saas.Monolithic.Models.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "Product");
            builder.HasKey(p => p.Id);
            builder.Property(product => product.ProductCode).IsRequired();
            builder.Property(product => product.Title).IsRequired().HasMaxLength(50);
            builder.Property(product => product.UnitPrice).IsRequired().HasMaxLength(50);
            builder.Property(product => product.DateCreation).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(product => product.DateModification).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(product => product.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
