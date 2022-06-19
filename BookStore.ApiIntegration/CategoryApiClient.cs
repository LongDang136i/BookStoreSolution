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
            var data = await GetAsync<ApiResult<PagedResult<CategoryVm>>>($"/api/categories/paging?" +
                $"pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}" +
                $"&languageId={request.LanguageId}");

            return data;
        }

        public async Task<ApiResult<bool>> CreateCategory(CreateCategoryRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var data = await PostAsync<ApiResult<bool>>($"/api/categories", httpContent);

            return data;
        }

        public async Task<ApiResult<bool>> EditCategory(int categoryId, EditCategoryRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu qua lớp cha
            var data = await PutAsync<ApiResult<bool>>($"/api/categories/{categoryId}", httpContent);

            return data;
        }

        public async Task<ApiResult<bool>> DeleteCategory(int categoryId)
        {
            //Lấy dữ liệu qua lớp cha
            var data = await DeleteAsync<ApiResult<bool>>($"/api/categories/{categoryId}");

            return data;
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<List<CategoryVm>> GetAllCategories(string languageId)
        {
            return await GetListAsync<CategoryVm>($"/api/categories?languageId=" + languageId);
        }

        public async Task<CategoryVm> GetCategoryById(string languageId, int categoryId)
        {
            return await GetAsync<CategoryVm>($"/api/categories/{categoryId}/{languageId}");
        }

        #endregion Both Admin & Web App
    }
}