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

        Task<ApiResult<int>> CreateCategory(CreateCategoryRequest request);

        Task<ApiResult<int>> EditCategory(EditCategoryRequest request);

        Task<ApiResult<bool>> DeleteCategory(int categoryId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<List<CategoryVm>>> GetAllCategories(string languageId);

        Task<ApiResult<CategoryVm>> GetCategoryById(string languageId, int categoryId);

        #endregion Both Admin & Web App
    }
}