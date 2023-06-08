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
        }
    }
}
