using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Configurations
{
    public class BrandTranslationConfiguration : IEntityTypeConfiguration<BrandTranslation>
    {
        public void Configure(EntityTypeBuilder<BrandTranslation> builder)
        {
            builder.ToTable("BrandTranslations");

            builder.HasKey(x => x.BrandTrId);

            builder.Property(x => x.BrandTrId).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoDescription).HasMaxLength(500);

            builder.Property(x => x.SeoTitle).HasMaxLength(200);

            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.BrandTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.Brand).WithMany(x => x.BrandTranslations).HasForeignKey(x => x.BrandId);
        }
    }
}