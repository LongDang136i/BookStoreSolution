using BookStore.ApiIntegration.Interface;
using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        public UserApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        { }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUsersPagingRequest request)
        {
            //Lấy dữ liệu qua lớp cha
            var data = await GetAsync<ApiResult<PagedResult<UserVm>>>($"/api/users/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");

            return data;
        }

        public async Task<ApiResult<bool>> EditUser(Guid id, EditUserRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu qua lớp cha
            var data = await PutAsync<ApiResult<bool>>($"/api/users/{id}", httpContent);

            return data;
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid userId)
        {
            //Lấy dữ liệu qua lớp cha
            var data = await DeleteAsync<ApiResult<bool>>($"/api/users/{userId}");

            return data;
        }

        public Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu thông qua lớp cha BaseApiClient
            var data = await PostAsync<ApiResult<string>>($"/api/users/authenticate", httpContent);

            //Trả kết quả cho Controller
            return data;
        }

        public async Task<ApiResult<bool>> RegisterUser(RegisterRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var data = await PostAsync<ApiResult<bool>>($"/api/users", httpContent);

            return data;
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid userId)
        {
            //Lấy dữ liệu qua lớp cha
            return await GetAsync<ApiResult<UserVm>>($"/api/users/{userId}");
        }

        #endregion Both Admin & Web App

        //public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = new Uri(_configuration["BaseAddress"]);
        //    var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

        //    var json = JsonConvert.SerializeObject(request);
        //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await client.PutAsync($"/api/users/{id}/roles", httpContent);
        //    var result = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //        return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);

        //    return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        //}
    }
}