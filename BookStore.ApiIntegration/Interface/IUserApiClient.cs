using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface IUserApiClient
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<bool>> EditUser(Guid userId, EditUserRequest request);

        Task<ApiResult<bool>> DeleteUser(Guid userId);

        Task<ApiResult<bool>> RoleAssign(Guid userId, RoleAssignRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);

        #endregion Both Admin & Web App
    }
}