using BookStore.Data.Entities;
using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Application.Catalog.Products
{
    public interface IProductService
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<ApiResult<int>> CreateProduct(CreateProductRequest request);

        Task<ApiResult<int>> EditProduct(EditProductRequest request);

        Task<ApiResult<bool>> DeleteProduct(int productId);

        //Task<int> RemoveProductImage(int imageId);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<ProductInfoVm>> GetProductById(string languageId, int productId);

        Task<ApiResult<PagedResult<ProductInfoVm>>> GetProductsPaging(GetProductsPagingRequest request);

        #endregion Both Admin & Web App

        //---------------------------------------------------------------------------------//

        #region Web App

        Task<ApiResult<List<ProductInfoVm>>> GetCollectionProducts(string languageId, int take);

        Task<ApiResult<List<ProductInfoVm>>> GetFeaturedProducts(string languageId, int take);

        Task<ApiResult<List<ProductInfoVm>>> GetLatestProducts(string languageId, int take);

        #endregion Web App
    }
}