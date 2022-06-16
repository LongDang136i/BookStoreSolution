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

        Task<int> CreateProduct(ProductCreateRequest request);

        Task<int> UpdateProduct(ProductUpdateRequest request);

        Task<int> DeleteProduct(int productId);

        Task<int> AddProductImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveProductImage(int imageId);

        Task<int> UpdateProductImage(int imageId, ProductImageUpdateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ProductVm> GetProductById(int productId, string languageId);

        Task<PagedResult<ProductVm>> GetAllProductPaging(GetProductPagingRequest request);

        Task<PagedResult<ProductVm>> GetProductByCategoryId(string languageId, GetProductPagingRequest request);

        Task<ProductImageVm> GetProductImageById(int imageId);

        Task<List<ProductImageVm>> GetListProductImages(int productId);

        #endregion Both Admin & Web App
    }
}