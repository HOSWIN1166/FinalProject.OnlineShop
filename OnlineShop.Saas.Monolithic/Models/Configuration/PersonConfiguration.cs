using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Saas.Monolithic.Models.DomainModels.PersonAggregates;

namespace OnlineShop.Saas.Monolithic.Models.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "Person");
            builder.HasKey(person => person.Id);
            builder.Property(person => person.FName).IsRequired().HasMaxLength(50);
            builder.Property(person => person.LName).IsRequired().HasMaxLength(50);
            builder.Property(person => person.IsDelete).IsRequired().HasDefaultValue(false);
        }
    }
}
