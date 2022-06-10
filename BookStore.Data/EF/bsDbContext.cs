using BookStore.Data.Configurations;
using BookStore.Data.Entities;
using BookStore.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.EF
{
    //Kế thừa class DbContext
    public class bsDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public bsDbContext(DbContextOptions options) : base(options)
        {
        }

        //Ghi đè hàm khởi tạo để áp dụng các thiết lập cho csdl
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //gọi thiết lập csdl bằng Fluent API

            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new BrandTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());

            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInBrandConfiguration());

            modelBuilder.ApplyConfiguration(new SlideConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId); ;
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");

            //tạo dữ liệu mẫu
            modelBuilder.Seed();
        }

        //Các bảng có trong CSDL

        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Language> Languages { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<BrandTranslation> BrandTranslations { get; set; }

        public DbSet<ProductInCategory> ProductInCategories { get; set; }
        public DbSet<ProductInBrand> ProductInBrands { get; set; }

        public DbSet<Slide> Slides { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}