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

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUsersPagingRequest request);

        Task<ApiResult<bool>> EditUser(EditUserRequest request);

        Task<ApiResult<bool>> DeleteUser(Guid userId);

        Task<ApiResult<bool>> RoleAssign(RoleAssignRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);

        Task<ApiResult<UserVm>> GetUserById(Guid id);

        #endregion Both Admin & Web App
    }
}