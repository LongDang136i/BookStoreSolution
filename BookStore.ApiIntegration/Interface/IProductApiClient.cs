using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface IProductApiClient
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<ApiResult<PagedResult<ProductInfoVm>>> GetProductsPaging(GetProductsPagingRequest request);

        Task<ApiResult<int>> CreateProduct(CreateProductRequest request);

        Task<ApiResult<int>> EditProduct(EditProductRequest request);

        Task<ApiResult<bool>> DeleteProduct(int productId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<ProductInfoVm>> GetProductById(string languageId, int productId);

        Task<ApiResult<List<ProductImageVm>>> GetProductImageByProductId(int productId);

        #endregion Both Admin & Web App

        //---------------------------------------------------------------------------------//

        #region Web App

        Task<ApiResult<List<ProductInfoVm>>> GetFeaturedProducts(string languageId, int take);

        Task<ApiResult<List<ProductInfoVm>>> GetLatestProducts(string languageId, int take);

        #endregion Web App
    }
}