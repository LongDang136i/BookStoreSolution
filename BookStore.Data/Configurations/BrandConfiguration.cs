using BookStore.Data.Entities;
using BookStore.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(x => x.BrandId);

            builder.Property(x => x.BrandId).UseIdentityColumn();

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}