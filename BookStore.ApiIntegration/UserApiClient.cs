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
            return await GetAsync<ApiResult<PagedResult<UserVm>>>($"/api/users/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
        }

        public async Task<ApiResult<bool>> EditUser(EditUserRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu qua lớp cha
            return await PutAsync<ApiResult<bool>>($"/api/users/{request.UserId}", httpContent);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid userId)
        {
            //Lấy dữ liệu qua lớp cha
            return await DeleteAsync<ApiResult<bool>>($"/api/users/{userId}");
        }

        public async Task<ApiResult<bool>> RoleAssign(RoleAssignRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu thông qua lớp cha
            return await PutAsync<ApiResult<bool>>($"/api/users/{request.UserId}/roles", httpContent);
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu thông qua lớp cha
            return await PostAsync<ApiResult<string>>($"/api/users/authenticate", httpContent);
        }

        public async Task<ApiResult<bool>> RegisterUser(RegisterRequest request)
        {
            //Biên dịch request ra json và đổi sang kiểu StringContent
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Lấy dữ liệu thông qua lớp cha
            return await PostAsync<ApiResult<bool>>($"/api/users", httpContent);
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid userId)
        {
            //Lấy dữ liệu qua lớp cha
            return await GetAsync<ApiResult<UserVm>>($"/api/users/{userId}");
        }

        #endregion Both Admin & Web App
    }
}