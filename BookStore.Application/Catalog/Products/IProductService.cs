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

        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        //Task<bool> UpdatePrice(int productId, decimal newPrice);

        //Task<bool> UpdateStock(int productId, int addedQuantity);

        //Task AddViewcount(int productId);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request);

        Task<ProductImageVm> GetImageById(int imageId);

        Task<List<ProductImageVm>> GetListImages(int productId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ProductVm> GetById(int productId, string languageId);

        Task<PagedResult<ProductVm>> GetAllPaging(GetProductPagingRequest request);

        Task<PagedResult<ProductVm>> GetAllByCategoryId(string languageId, GetProductPagingRequest request);

        #endregion Both Admin & Web App
    }
}