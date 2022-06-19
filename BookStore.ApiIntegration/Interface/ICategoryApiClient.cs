using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAllCategories(string languageId);

        Task<CategoryVm> GetCategoryById(string languageId, int categoryId);
    }
}