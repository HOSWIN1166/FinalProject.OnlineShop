﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Saas.Models.DomainModels.PersonAggregates;

namespace OnlineShop.Saas.Models.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", "Person");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LName).IsRequired().HasMaxLength(50);
        }
    }
}
