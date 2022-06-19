using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<ApiResult<PagedResult<CategoryVm>>> GetCategoriesPaging(GetCategoriesPagingRequest request);

        Task<ApiResult<bool>> CreateCategory(CreateCategoryRequest request);

        Task<ApiResult<bool>> EditCategory(EditCategoryRequest request);

        Task<ApiResult<bool>> DeleteCategory(int categoryId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<CategoryVm>> GetAllCategories(string languageId);

        Task<CategoryVm> GetCategoryById(string languageId, int categoryId);

        #endregion Both Admin & Web App
    }
}