using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface ICategoryApiClient
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<ApiResult<PagedResult<CategoryVm>>> GetCategoriesPaging(GetCategoriesPagingRequest request);

        Task<ApiResult<bool>> CreateCategory(CreateCategoryRequest request);

        Task<ApiResult<bool>> EditCategory(int categoryId, EditCategoryRequest request);

        Task<ApiResult<bool>> DeleteCategory(int categoryId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<CategoryVm>> GetAllCategories(string languageId);

        Task<CategoryVm> GetCategoryById(string languageId, int categoryId);

        #endregion Both Admin & Web App
    }
}