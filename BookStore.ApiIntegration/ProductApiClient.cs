using BookStore.ApiIntegration.Interface;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using BookStore.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookStore.ViewModels.Catalog.ProductImages;

namespace BookStore.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<ApiResult<PagedResult<ProductInfoVm>>> GetProductsPaging(GetProductsPagingRequest request)
        {
            var data = await GetAsync<ApiResult<PagedResult<ProductInfoVm>>>($"/api/products/paging?" +
                $"pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}" +
                $"&languageId={request.LanguageId}" +
                $"&categoryId={request.CategoryId}" +
                $"&sortBy={request.SortBy}");

            return data;
        }

        public async Task<ApiResult<int>> CreateProduct(CreateProductRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.DefaultImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.DefaultImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.DefaultImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "defaultImage", request.DefaultImage.FileName);
            }
            if (request.ProductImages != null)
            {
                foreach (var image in request.ProductImages)
                {
                    byte[] data;
                    using (var br = new BinaryReader(image.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)image.OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "productImages", image.FileName);
                }
            }
            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Details) ? "" : request.Details.ToString()), "details");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(request.IsFeatured.ToString()), "isFeatured");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/products/", requestContent);

            //var json = JsonConvert.SerializeObject(request.CategoryAssign);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //var responseCat = await client.PutAsync($"/api/products/{request.ProductId}/categories", httpContent);
            //Kiểm tra kết quả và trả về
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<int>("Create new product successful!");
            }
            return new ApiErrorResult<int>("Problem when create new product");
        }

        public async Task<ApiResult<int>> EditProduct(EditProductRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.DefaultImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.DefaultImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.DefaultImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "defaultImage", request.DefaultImage.FileName);
            }
            if (request.ProductImages != null)
            {
                foreach (var image in request.ProductImages)
                {
                    byte[] data;
                    using (var br = new BinaryReader(image.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)image.OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "productImages", image.FileName);
                }
            }
            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Details) ? "" : request.Details.ToString()), "details");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            requestContent.Add(new StringContent(request.IsFeatured.ToString()), "isFeatured");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PutAsync($"/api/products/" + request.ProductId, requestContent);

            var json = JsonConvert.SerializeObject(request.CategoryAssign);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var responseCat = await client.PutAsync($"/api/products/{request.ProductId}/categories", httpContent);
            //Kiểm tra kết quả và trả về
            if (response.IsSuccessStatusCode)
            {
                return new ApiSuccessResult<int>("Update product information successful!");
            }
            return new ApiErrorResult<int>("Problem when update product information!");
        }

        public async Task<ApiResult<bool>> DeleteProduct(int productId)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/products/{productId}");
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<ProductInfoVm>> GetProductById(string languageId, int productId)
        {
            var data = await GetAsync<ApiResult<ProductInfoVm>>($"/api/products/{productId}/{languageId}");

            return data;
        }

        public async Task<ApiResult<List<ProductImageVm>>> GetProductImageByProductId(int productId)
        {
            var data = await GetAsync<ApiResult<List<ProductImageVm>>>($"/api/products/productimages/{productId}/");

            return data;
        }

        #endregion Both Admin & Web App

        //---------------------------------------------------------------------------------//

        #region Web App

        public async Task<ApiResult<List<ProductInfoVm>>> GetCollectionProducts(string languageId, int take)
        {
            var data = await GetAsync<ApiResult<List<ProductInfoVm>>>($"/api/products/collection/{languageId}/{take}");
            return data;
        }
        public async Task<ApiResult<List<ProductInfoVm>>> GetFeaturedProducts(string languageId, int take)
        {
            var data = await GetAsync<ApiResult<List<ProductInfoVm>>>($"/api/products/featured/{languageId}/{take}");
            return data;
        }

        public async Task<ApiResult<List<ProductInfoVm>>> GetLatestProducts(string languageId, int take)
        {
            var data = await GetAsync<ApiResult<List<ProductInfoVm>>>($"/api/products/latest/{languageId}/{take}");
            return data;
        }

        #endregion Web App
    }
}