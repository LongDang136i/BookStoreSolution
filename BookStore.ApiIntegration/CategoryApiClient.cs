using BookStore.ApiIntegration.Interface;
using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        { }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<ApiResult<PagedResult<CategoryVm>>> GetCategoriesPaging(GetCategoriesPagingRequest request)
        {
            //Tạo đường dẫn gọi đến BackEndApi thông qua lớp cha để lấy dữ liệu
            return await GetAsync<ApiResult<PagedResult<CategoryVm>>>($"/api/categories/paging?" +
                $"pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}" +
                $"&languageId={request.LanguageId}");
        }

        public async Task<ApiResult<bool>> CreateCategory(CreateCategoryRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Tạo đường dẫn gọi đến BackEndApi thông qua lớp cha để lấy dữ liệu
            return await PostAsync<ApiResult<bool>>($"/api/categories", httpContent);
        }

        public async Task<ApiResult<bool>> EditCategory(EditCategoryRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Tạo đường dẫn gọi đến BackEndApi thông qua lớp cha để lấy dữ liệu
            return await PutAsync<ApiResult<bool>>($"/api/categories/{request.CategoryId}", httpContent);
        }

        public async Task<ApiResult<bool>> DeleteCategory(int categoryId)
        {
            //Tạo đường dẫn gọi đến BackEndApi thông qua lớp cha để lấy dữ liệu
            return await DeleteAsync<ApiResult<bool>>($"/api/categories/{categoryId}");
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<List<CategoryVm>>> GetAllCategories(string languageId)
        {
            //Tạo đường dẫn gọi đến BackEndApi thông qua lớp cha để lấy dữ liệu
            return await GetAsync<ApiResult<List<CategoryVm>>>($"/api/categories?languageId=" + languageId);
        }

        public async Task<ApiResult<CategoryVm>> GetCategoryById(string languageId, int categoryId)
        {
            //Tạo đường dẫn gọi đến BackEndApi thông qua lớp cha để lấy dữ liệu
            return await GetAsync<ApiResult<CategoryVm>>($"/api/categories/{categoryId}/{languageId}");
        }

        #endregion Both Admin & Web App
    }
}