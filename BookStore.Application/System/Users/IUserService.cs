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

        Task<ApiResult<bool>> UpdateUser(Guid id, EditUserRequest request);

        Task<ApiResult<bool>> DeleteUser(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<UserVm>> GetUserById(Guid id);

        #endregion Both Admin & Web App
    }
}