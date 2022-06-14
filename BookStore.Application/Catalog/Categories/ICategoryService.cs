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

        Task<int> Create(CategoryCreateRequest request);

        Task<int> Update(CategoryUpdateRequest request);

        Task<int> Delete(int categoryId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        //

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int categoryId);

        #endregion Both Admin & Web App
    }
}