using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductListPagingVm>>> GetProductsPaging(GetProductsPagingRequest request);

        Task<ApiResult<int>> CreateProduct(CreateProductRequest request);

        Task<ApiResult<int>> EditProduct(EditProductRequest request);

        Task<ApiResult<bool>> DeleteProduct(int productId);

        //Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        Task<ApiResult<ProductDetailVm>> GetProductById(string languageId, int productId);

        //Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        //Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

        Task<ApiResult<List<ProductImageVm>>> GetProductImageByProductId(int productId);
    }
}