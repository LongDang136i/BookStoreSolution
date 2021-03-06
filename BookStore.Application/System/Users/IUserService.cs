using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.System.Users
{
    public interface IUserService
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUsersPagingRequest request);

        Task<ApiResult<bool>> EditUser(EditUserRequest request);

        Task<ApiResult<bool>> DeleteUser(Guid id);

        Task<ApiResult<bool>> RoleAssign(RoleAssignRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<UserVm>> GetUserById(Guid id);

        #endregion Both Admin & Web App
    }
}