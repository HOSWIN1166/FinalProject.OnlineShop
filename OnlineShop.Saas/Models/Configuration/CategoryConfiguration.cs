using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Saas.Models.DomainModels.PersonAggregates;

namespace OnlineShop.Saas.Models.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "Product");
            builder.HasKey(p => p.Id);
        }
    }
}
