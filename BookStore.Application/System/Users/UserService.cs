using BookStore.Data.Entities;
using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Users;
using BookStore.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<ApiResult<bool>> EditUser(Guid id, EditUserRequest request)
        {
            //Ktra nếu email nhập vào đã tồn tại ở người dùng khác
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Email has been register by another user");
            }

            //Thõa điều kiện thì lấy ra user theo id, gán thông tin mới
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Dob = request.Dob;
            user.Email = request.Email;
            user.FisrtName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            //thực thi và kiểm tra kq trả về
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Can not update user");
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUsersPagingRequest request)
        {
            //Lấy ra user theo từ khóa được nhập
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                || x.PhoneNumber.Contains(request.Keyword)
                || x.FisrtName.Contains(request.Keyword)
                || x.LastName.Contains(request.Keyword)
                || x.Email.Contains(request.Keyword));
            }

            //Đếm tổng bản ghi
            int totalRow = await query.CountAsync();

            /*Chọn lọc dữ liệu:
             * - Bỏ qua n bản ghi với n = (PageIndex -1) * PageSize (ví dụ trang thứ 3 sẽ bỏ qua (3-1) * 10 = 20, bắt đầu lấy từ bản ghi 21
             * - Lấy pageSize bản ghi cho vào List
             */
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName,
                    FirstName = x.FisrtName,
                    LastName = x.LastName,
                    UserId = x.Id,
                    Dob = x.Dob,
                }).ToListAsync();

            //Tạo thông tin cho trang kết quả
            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data,
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            //Lấy ra user theo id, nếu ko tìm đc thì báo lỗi
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User don't exist");
            }
            //Thực hiện xóa và ktra kq trả về
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new ApiSuccessResult<bool>();
            return new ApiErrorResult<bool>("Delete fail");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            //Lấy ra user theo id, nếu ko tìm đc thì báo lỗi
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User don't exist");
            }

            /*Tạo danh sách các role chưa được gán, với mỗi role trong danh sách,
            chạy vòng lặp ktra nếu có tồn tại user với thông tin role như vậy thì xóa role*/
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            /*Tạo danh sách các role đã được gán, với mỗi role trong danh sách,
            chạy vòng lặp ktra nếu ko có tồn tại user với thông tin role như vậy thì tạo role*/
            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            //Lấy ra user theo tên đăng nhập
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiErrorResult<string>("Username don't exist");

            //Kiểm tra mật khẩu nhập vào có đúng ko
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Wrong password");
            }

            //Lấy ra role của user
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FisrtName),
                new Claim(ClaimTypes.Role,String.Join(";",roles)),
                new Claim(ClaimTypes.Name,request.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            //Lấy và kiểm tra tên người dùng, email đã tồn tại chưa
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Username has been register by another user");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Email has been register by another user");
            }
            //Tạo thông tin người dùng mới từ request
            user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FisrtName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName,
            };

            //Thực hiện tạo mới người dùng và ktra kq trả về
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Register fail");
        }

        public async Task<ApiResult<UserVm>> GetUserById(Guid id)
        {
            //Lấy và kiểm tra người dùng theo id
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserVm>("Username don't exist");
            }
            //Lấy thông tin role của user
            var roles = await _userManager.GetRolesAsync(user);
            //Gán thông tin và trả kết quả
            var userVm = new UserVm()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                FirstName = user.FisrtName,
                LastName = user.LastName,
                Dob = user.Dob,
                UserId = user.Id,
                Roles = roles,
            };
            return new ApiSuccessResult<UserVm>(userVm);
        }

        #endregion Both Admin & Web App
    }
}