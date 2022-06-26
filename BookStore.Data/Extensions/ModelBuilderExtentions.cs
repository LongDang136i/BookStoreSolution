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

            //-------------------------------------IdentityUserRole--------------------------------------------------//

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

            //-------------------------------------Language--------------------------------------------------//
            modelBuilder.Entity<Language>().HasData(
                new Language() { LanguageId = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { LanguageId = "en", Name = "English", IsDefault = false }
                );

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

            //---------------------------------AppConfig------------------------------------------------------//
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "This is home page" },
              new AppConfig() { Key = "HomeKeyword", Value = "This is keyword" },
              new AppConfig() { Key = "HomeDescription", Value = "This is description" }
              );
        }
    }
}