using BookStore.ViewModels.Catalog.Categories;
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

        Task<int> CreateCategory(CreateCategoryRequest request);

        Task<int> UpdateCategory(UpdateCategoryRequest request);

        Task<int> DeleteCategory(int categoryId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        //

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<CategoryVm>> GetAllCategories(string languageId);

        Task<CategoryVm> GetCategoryById(string languageId, int categoryId);

        #endregion Both Admin & Web App
    }
}