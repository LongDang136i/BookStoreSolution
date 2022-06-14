using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPagings(GetProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<bool> UpdateProduct(ProductUpdateRequest request);

        Task<bool> DeleteProduct(int productId);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}