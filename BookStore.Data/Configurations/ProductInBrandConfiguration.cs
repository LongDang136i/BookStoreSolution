using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Configurations
{
    public class ProductInBrandConfiguration : IEntityTypeConfiguration<ProductInBrand>
    {
        public void Configure(EntityTypeBuilder<ProductInBrand> builder)
        {
            builder.HasKey(t => new { t.BrandId, t.ProductId });

            builder.ToTable("ProductInBrands");

            builder.HasOne(p => p.Product).WithMany(pb => pb.ProductInBrands)
                .HasForeignKey(pb => pb.ProductId);

            builder.HasOne(b => b.Brand).WithMany(pb => pb.ProductInBrands)
              .HasForeignKey(pb => pb.BrandId);

            //builder.ToTable("ProductInCategories");

            ////Tạo khóa ngoại từ bảng trung gian đến các bảng chính
            ////đến bảng Product
            //builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInCategories)
            //    .HasForeignKey(pc => pc.ProductId);

            ////đến bảng Category
            //builder.HasOne(t => t.Category).WithMany(pc => pc.ProductInCategories)
            //  .HasForeignKey(pc => pc.CategoryId);
        }
    }
}