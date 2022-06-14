using BookStore.Data.EF;
using BookStore.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.Data.Entities;
using BookStore.Utilities.Constants;
using BookStore.Utilities.Exceptions;

namespace BookStore.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly bsDbContext _context;

        public CategoryService(bsDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<int> Create(CategoryCreateRequest request)
        {
            //Lấy danh sách ngôn ngữ
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();

            //Chạy vòng lặp: Với mỗi ngôn ngữ có đc, so sánh với ngôn ngữ của request: tạo CategoryTranslation với ngôn ngữ tương ứng
            foreach (var language in languages)
            {
                if (language.LanguageId == request.LanguageId)
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = request.Name,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        SeoAlias = request.SeoAlias,
                        LanguageId = language.LanguageId,
                    });
                }
                else
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = SystemConstants.DefaultValueConstant.NA,
                        SeoDescription = SystemConstants.DefaultValueConstant.NA,
                        SeoAlias = SystemConstants.DefaultValueConstant.NA,
                        SeoTitle = SystemConstants.DefaultValueConstant.NA,
                        LanguageId = language.LanguageId
                    });
                }
            }
            //Tạo mới một category với thông tin nhập vào (lưu vào bảng Categories)
            var category = new Category()
            {
                SortOrder = request.SortOrder,
                Status = request.Status,
                ParentId = request.ParentId,
                IsShowOnHome = request.IsShowOnHome,
                CategoryTranslations = translations
            };

            //Thêm danh mục vào csdl
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<int> Update(CategoryUpdateRequest request)
        {
            //Lấy thông tin category,categoryTranslation theo id từ request,
            var category = await _context.Categories.FindAsync(request.CategoryId);
            var categoryTranslation = await _context.CategoryTranslations.FirstOrDefaultAsync(
                x => x.CategoryId == request.CategoryId
                && x.LanguageId == request.LanguageId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (category == null || categoryTranslation == null) throw new BookStoreException($"Cannot find a category with id: {request.CategoryId}");

            //Nếu tìm được category, gán lại thông tin mới từ request
            category.Status = request.Status;
            category.SortOrder = request.SortOrder;
            category.IsShowOnHome = request.IsShowOnHome;
            category.ParentId = request.ParentId;
            categoryTranslation.Name = request.Name;
            categoryTranslation.SeoAlias = request.SeoAlias;
            categoryTranslation.SeoDescription = request.SeoDescription;
            categoryTranslation.SeoTitle = request.SeoTitle;

            //Thực thi
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int categoryId)
        {
            //Lấy thông tin category,categoryTranslation theo id từ request,
            var category = await _context.Categories.FindAsync(categoryId);
            var categoryTranslation = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == categoryId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (category == null || categoryTranslation == null) throw new BookStoreException($"Cannot find a category: {categoryId}");

            //Xóa cả category trong bảng Categories, và categoryTranslation trong bảng CategoryTranslations
            _context.Categories.Remove(category);
            _context.CategoryTranslations.Remove(categoryTranslation);

            return await _context.SaveChangesAsync();
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        //

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            //1. Select join
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                CategoryId = x.c.CategoryId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById(string languageId, int categoryId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                        where ct.LanguageId == languageId && c.CategoryId == categoryId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                CategoryId = x.c.CategoryId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();
        }

        #endregion Both Admin & Web App
    }
}