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

        Task<ApiResult<PagedResult<ProductListPagingVm>>> GetProductsPaging(GetProductsPagingRequest request);

        Task<ApiResult<int>> CreateProduct(CreateProductRequest request);

        Task<ApiResult<int>> EditProduct(EditProductRequest request);

        Task<ApiResult<bool>> DeleteProduct(int productId);

        //Task<int> CreateProductImage(int productId, CreateProductImageRequest request);

        //Task<int> RemoveProductImage(int imageId);

        //Task<int> UpdateProductImage(int imageId, EditProductImageRequest request);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<ProductDetailVm>> GetProductById(string languageId, int productId);

        Task<ApiResult<List<ProductImageVm>>> GetProductImageByProductId(int productId);

        Task<PagedResult<ProductVm>> GetProductByCategoryId(string languageId, GetProductsPagingRequest request);

        Task<ProductImageVm> GetProductImageById(int imageId);

        Task<List<ProductImageVm>> GetListProductImages(int productId);

        #endregion Both Admin & Web App
    }
}