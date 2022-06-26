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
using BookStore.ViewModels.Common;
using Microsoft.Extensions.Configuration;

namespace BookStore.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly bsDbContext _context;
        //private readonly IConfiguration _config;

        public CategoryService(bsDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<ApiResult<PagedResult<CategoryVm>>> GetCategoriesPaging(GetCategoriesPagingRequest request)
        {
            //Tạo query
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                        //default
                        where ct.LanguageId == request.LanguageId
                        select new { c, ct };

            //2. Lọc dữ liệu
            //Nếu từ khóa khác rỗng, chỉ lấy ra những CategoryTranslations có từ khóa trong tên
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));

            //3. Phân trang
            //Lấy ra tổng số bản ghi
            int totalRow = await query.CountAsync();

            //Tạo data cho từng trang, lấy ra danh sách bản ghi nhất định
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CategoryVm()
                {
                    CategoryId = x.c.CategoryId,
                    SortOrder = x.c.SortOrder,
                    IsShowOnHome = x.c.IsShowOnHome,
                    ParentId = x.c.ParentId,
                    Status = x.c.Status,
                    Name = x.ct.Name,
                    SeoDescription = x.ct.SeoDescription,
                    SeoTitle = x.ct.SeoTitle,
                    LanguageId = x.ct.LanguageId,
                    SeoAlias = x.ct.SeoAlias,
                }).ToListAsync();

            //4. Tạo trang kết quả
            var pagedResult = new PagedResult<CategoryVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<CategoryVm>>(pagedResult);
        }

        public async Task<ApiResult<int>> CreateCategory(CreateCategoryRequest request)
        {
            //Lấy danh sách ngôn ngữ
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();

            //Chạy vòng lặp: Với mỗi ngôn ngữ có đc, so sánh với ngôn ngữ của request: tạo obj với ngôn ngữ tương ứng
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
            //Tạo mới một obj với thông tin nhập vào
            var category = new Category()
            {
                SortOrder = request.SortOrder,
                Status = request.Status,
                ParentId = request.ParentId,
                IsShowOnHome = request.IsShowOnHome,
                CategoryTranslations = translations
            };

            //Thêm obj vào csdl và ktra kqua
            _context.Categories.Add(category);
            if (await _context.SaveChangesAsync() > 0)
            {
                return new ApiSuccessResult<int>(category.CategoryId, "Create new category successful!");
            }
            return new ApiErrorResult<int>("Problem when create category!");
        }

        public async Task<ApiResult<int>> EditCategory(EditCategoryRequest request)
        {
            //Lấy thông tin theo id từ request,
            var category = await _context.Categories.FindAsync(request.CategoryId);
            var categoryTranslation = await _context.CategoryTranslations.FirstOrDefaultAsync(
                x => x.CategoryId == request.CategoryId
                && x.LanguageId == request.LanguageId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (category == null || categoryTranslation == null) return new ApiErrorResult<int>("Category doesn't exist anymore!");

            //Nếu tìm được obj, gán lại thông tin mới từ request
            category.Status = request.Status;
            category.SortOrder = request.SortOrder;
            category.IsShowOnHome = request.IsShowOnHome;
            category.ParentId = request.ParentId;
            categoryTranslation.Name = request.Name;
            categoryTranslation.SeoAlias = request.SeoAlias;
            categoryTranslation.SeoDescription = request.SeoDescription;
            categoryTranslation.SeoTitle = request.SeoTitle;

            //Lưu thay đổi và ktra
            if (await _context.SaveChangesAsync() > 0)
            {
                return new ApiSuccessResult<int>(category.CategoryId, "Update category information successful!");
            }
            return new ApiErrorResult<int>("Problem when update category information!");
        }

        public async Task<ApiResult<bool>> DeleteCategory(int categoryId)
        {
            //Lấy thông tin obj theo id từ request,
            var category = await _context.Categories.FindAsync(categoryId);
            var categoryTranslation = _context.CategoryTranslations.Where(x => x.CategoryId == categoryId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (category == null || categoryTranslation == null) return new ApiErrorResult<bool>("Category doesn't exist anymore!");

            //Xóa các bản ghi
            _context.Categories.Remove(category);

            foreach (var item in categoryTranslation)
            {
                _context.CategoryTranslations.Remove(item);
            }

            //Lưu thay đổi và ktra
            if (await _context.SaveChangesAsync() > 0)
            {
                return new ApiSuccessResult<bool>("Delete category successful!");
            }
            return new ApiErrorResult<bool>("Problem when delete category!");
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<List<CategoryVm>>> GetAllCategories(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            var result = await query.Select(x => new CategoryVm()
            {
                CategoryId = x.c.CategoryId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
            }).ToListAsync();

            //Ktra kq
            if (result == null)
            {
                return new ApiErrorResult<List<CategoryVm>>("Problem when get categories!");
            }
            return new ApiSuccessResult<List<CategoryVm>>(result);
        }

        public async Task<ApiResult<CategoryVm>> GetCategoryById(string languageId, int categoryId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                        where ct.LanguageId == languageId && c.CategoryId == categoryId
                        select new { c, ct };

            var result = await query.Select(x => new CategoryVm()
            {
                CategoryId = x.c.CategoryId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                SeoAlias = x.ct.SeoAlias,
                SeoDescription = x.ct.SeoDescription,
                SeoTitle = x.ct.SeoTitle,
                SortOrder = x.c.SortOrder,
                Status = x.c.Status,
                IsShowOnHome = x.c.IsShowOnHome,
                LanguageId = languageId
            }).FirstOrDefaultAsync();

            //Ktra kq
            if (result == null)
            {
                return new ApiErrorResult<CategoryVm>("Problem when get information of category!");
            }
            return new ApiSuccessResult<CategoryVm>(result);
        }

        #endregion Both Admin & Web App
    }
}