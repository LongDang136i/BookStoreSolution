using BookStore.Data.Entities;
using BookStore.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Data.Extensions
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Identity

            //-------------------------------------AppRole--------------------------------------------------//
            var roleId1 = new Guid("D4965CC8-FDAB-433F-AE1D-79540827DB5A");
            var roleId2 = new Guid("90057EE3-511A-4DE1-94C2-93898F1018D9");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole { Id = roleId1, Name = "admin", NormalizedName = "admin", Description = "Administrator Role" },
                new AppRole { Id = roleId2, Name = "user", NormalizedName = "user", Description = "User Role" }
                );

            //------------------------------------AppUser---------------------------------------------------//
            var hasher = new PasswordHasher<AppUser>();
            var adminId = new Guid("1CEE3D50-87BB-48D5-A493-376829C581C9");
            var userId = new Guid("1A744CCA-D50D-4369-8E41-3FE91DB7CB1D");
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser { Id = adminId, UserName = "Admin@123", NormalizedUserName = "admin", Email = "danglong136i@gmail.com", NormalizedEmail = "danglong136i@gmail.com", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "Admin@123"), SecurityStamp = string.Empty, FisrtName = "Long", LastName = "Dang", Dob = new DateTime(2000, 6, 13) },
                new AppUser { Id = userId, UserName = "User@123", NormalizedUserName = "user", Email = "danglong@gmail.com", NormalizedEmail = "danglong@gmail.com", EmailConfirmed = true, PasswordHash = hasher.HashPassword(null, "User@123"), SecurityStamp = string.Empty, FisrtName = "User", LastName = "Test", Dob = new DateTime(2000, 6, 13) }
                );

            //-------------------------------------IdentityUserRole--------------------------------------------------//
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { RoleId = roleId1, UserId = adminId },
                new IdentityUserRole<Guid> { RoleId = roleId2, UserId = userId }
                );

            #endregion Identity

            #region Category,Brand,Product

            //----------------------------------------------Category-----------------------------------------//
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, IsShowOnHome = true, ParentId = null, SortOrder = 1, Status = Status.Active, },
                new Category() { CategoryId = 2, IsShowOnHome = true, ParentId = null, SortOrder = 2, Status = Status.Active, },
                new Category() { CategoryId = 3, IsShowOnHome = true, ParentId = null, SortOrder = 3, Status = Status.Active, },
                new Category() { CategoryId = 4, IsShowOnHome = true, ParentId = null, SortOrder = 4, Status = Status.Active, },

                //childen category
                new Category() { CategoryId = 5, IsShowOnHome = true, ParentId = 1, SortOrder = 5, Status = Status.Active },
                new Category() { CategoryId = 6, IsShowOnHome = true, ParentId = 1, SortOrder = 6, Status = Status.Active, },
                new Category() { CategoryId = 7, IsShowOnHome = true, ParentId = 2, SortOrder = 7, Status = Status.Active, },
                new Category() { CategoryId = 8, IsShowOnHome = true, ParentId = 2, SortOrder = 8, Status = Status.Active, }
                );

            //-------------------------------------------Brand--------------------------------------------//
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { BrandId = 1, IsShowOnHome = true, SortOrder = 1, Status = Status.Active, },
                new Brand() { BrandId = 2, IsShowOnHome = true, SortOrder = 2, Status = Status.Active, },
                new Brand() { BrandId = 3, IsShowOnHome = true, SortOrder = 3, Status = Status.Active, }
                );

            //--------------------------------------------Product-------------------------------------------//
            modelBuilder.Entity<Product>().HasData(
               new Product() { ProductId = 1, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 2, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 3, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 4, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 6, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 7, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 8, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 9, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 10, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 11, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 12, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 13, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = true, },
               new Product() { ProductId = 14, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 15, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 16, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 17, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 18, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 19, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 20, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 21, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, },
               new Product() { ProductId = 22, DateCreated = DateTime.Now, OriginalPrice = 200000, Price = 210000, Stock = 10, ViewCount = 0, IsFeatured = false, });

            #endregion Category,Brand,Product

            #region Language & Translation: Product, Category, Brand

            //-------------------------------------Language--------------------------------------------------//
            modelBuilder.Entity<Language>().HasData(
                new Language() { LanguageId = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { LanguageId = "en", Name = "English", IsDefault = false }
                );

            #region

            //-------------------------------------------CategoryTranslation--------------------------------------------//
            modelBuilder.Entity<CategoryTranslation>().HasData(
                //vi
                new CategoryTranslation() { CategoryTrId = 1, CategoryId = 1, Name = "Văn Học", LanguageId = "vi", SeoAlias = "van-hoc", SeoDescription = "Văn Học", SeoTitle = "Văn Học" },
                new CategoryTranslation() { CategoryTrId = 2, CategoryId = 2, Name = "Sách Học Sinh", LanguageId = "vi", SeoAlias = "sach-hoc-sinh", SeoDescription = "Sách Học Sinh", SeoTitle = "Sách Học Sinh" },
                new CategoryTranslation() { CategoryTrId = 3, CategoryId = 3, Name = "Sách Ngoại Ngữ", LanguageId = "vi", SeoAlias = "sach-ngoai-ngu", SeoDescription = "Sách Ngoại Ngữ", SeoTitle = "Sách Ngoại Ngữ" },
                new CategoryTranslation() { CategoryTrId = 4, CategoryId = 4, Name = "Tâm Lí - Kĩ Năng Sống", LanguageId = "vi", SeoAlias = "tam-li-ki-nang-song", SeoDescription = "Tâm Lí - Kĩ Năng Sống", SeoTitle = "Tâm Lí - Kĩ Năng Sống" },

                new CategoryTranslation() { CategoryTrId = 5, CategoryId = 5, Name = "Light Novel", LanguageId = "vi", SeoAlias = "light-novel", SeoDescription = "Light Novel", SeoTitle = "Light Novel" },
                new CategoryTranslation() { CategoryTrId = 6, CategoryId = 6, Name = "Tiểu Thuyết", LanguageId = "vi", SeoAlias = "tieu-thuyet", SeoDescription = "Tiểu Thuyết", SeoTitle = "Tiểu Thuyết" },
                new CategoryTranslation() { CategoryTrId = 7, CategoryId = 7, Name = "Sách Giáo Khoa", LanguageId = "vi", SeoAlias = "sach-giao-khoa", SeoDescription = "Sách Giáo Khoa", SeoTitle = "Sách Giáo Khoa" },
                new CategoryTranslation() { CategoryTrId = 8, CategoryId = 8, Name = "Sách Tham Khảo", LanguageId = "vi", SeoAlias = "sach-tham-khao", SeoDescription = "Sách Tham Khảo", SeoTitle = "Sách Tham Khảo" },
                //en
                new CategoryTranslation() { CategoryTrId = 9, CategoryId = 1, Name = "Literature", LanguageId = "en", SeoAlias = "literature", SeoDescription = "Literature", SeoTitle = "Literature" },
                new CategoryTranslation() { CategoryTrId = 10, CategoryId = 2, Name = "Student Book", LanguageId = "en", SeoAlias = "student-book", SeoDescription = "Student Book", SeoTitle = "Student Book" },
                new CategoryTranslation() { CategoryTrId = 11, CategoryId = 3, Name = "Foreign Book", LanguageId = "en", SeoAlias = "foreign-book", SeoDescription = "Foreign Book", SeoTitle = "Foreign Book" },
                new CategoryTranslation() { CategoryTrId = 12, CategoryId = 4, Name = "Psychology - Life Skills", LanguageId = "en", SeoAlias = "psychology-life-skills", SeoDescription = "Psychology - Life Skills", SeoTitle = "Psychology - Life Skills" },

                new CategoryTranslation() { CategoryTrId = 13, CategoryId = 5, Name = "Light Novel", LanguageId = "en", SeoAlias = "light-novel", SeoDescription = "Light Novel", SeoTitle = "Light Novel" },
                new CategoryTranslation() { CategoryTrId = 14, CategoryId = 6, Name = "Novel", LanguageId = "en", SeoAlias = "novel", SeoDescription = "Novel", SeoTitle = "Novel" },
                new CategoryTranslation() { CategoryTrId = 15, CategoryId = 7, Name = "School Book", LanguageId = "en", SeoAlias = "school-book", SeoDescription = "School Book", SeoTitle = "School Book" },
                new CategoryTranslation() { CategoryTrId = 16, CategoryId = 8, Name = "Reference Book", LanguageId = "vi", SeoAlias = "reference-book", SeoDescription = "Reference Book", SeoTitle = "Reference Book" }
            );

            //----------------------------------------------BrandTranslation-----------------------------------------//
            modelBuilder.Entity<BrandTranslation>().HasData(
                //vi
                new BrandTranslation() { BrandTrId = 1, BrandId = 1, Name = "Nhà Xuất Bản X", LanguageId = "vi", SeoAlias = "nha-xuat-ban-x", SeoDescription = "Nhà Xuất Bản X", SeoTitle = "Nhà Xuất Bản X" },
                new BrandTranslation() { BrandTrId = 2, BrandId = 2, Name = "Nhà Xuất Bản Y", LanguageId = "vi", SeoAlias = "nha-xuat-ban-y", SeoDescription = "Nhà Xuất Bản Y", SeoTitle = "Nhà Xuất Bản Y" },
                new BrandTranslation() { BrandTrId = 3, BrandId = 3, Name = "Nhà Xuất Bản Z", LanguageId = "vi", SeoAlias = "nha-xuat-ban-z", SeoDescription = "Nhà Xuất Bản Z", SeoTitle = "Nhà Xuất Bản Z" },
                //en
                new BrandTranslation() { BrandTrId = 4, BrandId = 1, Name = "Publishing Company X", LanguageId = "en", SeoAlias = "publishing-company-x", SeoDescription = "Publishing Company X", SeoTitle = "Publishing Company X" },
                new BrandTranslation() { BrandTrId = 5, BrandId = 2, Name = "Publishing Company Y", LanguageId = "en", SeoAlias = "publishing-company-y", SeoDescription = "Publishing Company Y", SeoTitle = "Publishing Company Y" },
                new BrandTranslation() { BrandTrId = 6, BrandId = 3, Name = "Publishing Company Z", LanguageId = "en", SeoAlias = "publishing-company-z", SeoDescription = "Publishing Company Z", SeoTitle = "Publishing Company Z" }
            );

            //---------------------------------------ProductTranslation------------------------------------------------//

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation() { ProductTrId = 1, ProductId = 1, Name = "Áo sơ mi nam trắng Việt Tiến", LanguageId = "vi", SeoAlias = "ao-so-mi-nam-trang-viet-tien", SeoDescription = "Áo sơ mi nam trắng Việt Tiến", SeoTitle = "Áo sơ mi nam trắng Việt Tiến", Details = "Áo sơ mi nam trắng Việt Tiến", Description = "Áo sơ mi nam trắng Việt Tiến" },
                new ProductTranslation() { ProductTrId = 2, ProductId = 1, Name = "Viet Tien Men T-Shirt", LanguageId = "en", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "Viet Tien Men T-Shirt", SeoTitle = "Viet Tien Men T-Shirt", Details = "Viet Tien Men T-Shirt", Description = "Viet Tien Men T-Shirt" },
                new ProductTranslation() { ProductTrId = 3, ProductId = 2, Name = "Áo sơ mi nam trắng Việt Tiến", LanguageId = "vi", SeoAlias = "ao-so-mi-nam-trang-viet-tien", SeoDescription = "Áo sơ mi nam trắng Việt Tiến", SeoTitle = "Áo sơ mi nam trắng Việt Tiến", Details = "Áo sơ mi nam trắng Việt Tiến", Description = "Áo sơ mi nam trắng Việt Tiến" },
                new ProductTranslation() { ProductTrId = 4, ProductId = 2, Name = "Viet Tien Men T-Shirt", LanguageId = "en", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "Viet Tien Men T-Shirt", SeoTitle = "Viet Tien Men T-Shirt", Details = "Viet Tien Men T-Shirt", Description = "Viet Tien Men T-Shirt" },
                new ProductTranslation() { ProductTrId = 5, ProductId = 3, Name = "Áo sơ mi nam trắng Việt Tiến", LanguageId = "vi", SeoAlias = "ao-so-mi-nam-trang-viet-tien", SeoDescription = "Áo sơ mi nam trắng Việt Tiến", SeoTitle = "Áo sơ mi nam trắng Việt Tiến", Details = "Áo sơ mi nam trắng Việt Tiến", Description = "Áo sơ mi nam trắng Việt Tiến" },
                new ProductTranslation() { ProductTrId = 6, ProductId = 3, Name = "Viet Tien Men T-Shirt", LanguageId = "en", SeoAlias = "viet-tien-men-t-shirt", SeoDescription = "Viet Tien Men T-Shirt", SeoTitle = "Viet Tien Men T-Shirt", Details = "Viet Tien Men T-Shirt", Description = "Viet Tien Men T-Shirt" });

            #endregion Language & Translation: Product, Category, Brand

            #endregion Language & Translation: Product, Category, Brand

            #region Product In Category & Brand

            //---------------------------------------------ProductInCategory------------------------------------------//
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 },
                new ProductInCategory() { ProductId = 2, CategoryId = 2 },
                new ProductInCategory() { ProductId = 3, CategoryId = 3 });

            ////---------------------------------------------ProductInBrand------------------------------------------//
            modelBuilder.Entity<ProductInBrand>().HasData(
               new ProductInBrand() { ProductId = 1, BrandId = 1 },
               new ProductInBrand() { ProductId = 2, BrandId = 2 },
               new ProductInBrand() { ProductId = 3, BrandId = 3 });

            #endregion Product In Category & Brand

            #region Slide & Order

            //--------------------------------------Slide-------------------------------------------------//
            modelBuilder.Entity<Slide>().HasData(
              new Slide() { SlideId = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
              new Slide() { SlideId = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
              new Slide() { SlideId = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
              new Slide() { SlideId = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { SlideId = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { SlideId = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );

            //---------------------------------AppConfig------------------------------------------------------//
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
              new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
              new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
              );

            #endregion Slide & Order
        }
    }
}