using BookStore.ApiIntegration.Interface;
using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration
{
    public class RoleApiClient : BaseApiClient, IRoleApiClient
    {
        public RoleApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        { }

        public async Task<ApiResult<List<RoleVm>>> GetAllRoles()
        {
            return await GetAsync<ApiResult<List<RoleVm>>>($"/api/roles");
        }
    }
}