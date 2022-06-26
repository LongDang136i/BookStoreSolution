using BookStore.ApiIntegration.Interface;
using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BookStore.AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private IUserApiClient _userApiClient;
        private IRoleApiClient _roleApiClient;
        private IConfiguration _configuration;

        public UserController(IUserApiClient userApiClient, IConfiguration configuration, IRoleApiClient roleApiClient)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
            _roleApiClient = roleApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            //Lấy Token Authorize
            var sessions = HttpContext.Session.GetString("Token");

            //Tạo request
            var request = new GetUsersPagingRequest()
            {
                BearerToken = sessions,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            //Gửi request
            var data = await _userApiClient.GetUsersPaging(request);

            //tạo ViewBag lưu từ khóa cho ô tìm kiếm
            ViewBag.Keyword = keyword;

            //Thông báo kết quả bằng TempData
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            //Trả về kết quả
            return View(data.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //Đăng xuất xóa thông tin Cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //Xóa token xác minh thông tin đăng nhập
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //gửi request đăng kí người dùng
            var result = await _userApiClient.RegisterUser(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(Guid id)
        {
            var result = await _userApiClient.GetUserById(id);
            if (result.IsSuccessed)
            {
                var user = result.ResultObj;
                var updateRequest = new EditUserRequest()
                {
                    Dob = user.Dob,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserId = id,
                    PhoneNumber = user.PhoneNumber,
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.EditUser(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public IActionResult DeleteUser(Guid id)
        {
            return View(new DeleteUserRequest() { UserId = id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userApiClient.DeleteUser(request.UserId);
            if (result.IsSuccessed)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> RoleAssign(Guid id)
        {
            var roleAssignRequest = await GetRoleAssignRequest(id);
            roleAssignRequest.UserId = id;
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAssign(RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _userApiClient.RoleAssign(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }

            var roleAssignRequest = await GetRoleAssignRequest(request.UserId);

            return View(roleAssignRequest);
        }

        private async Task<RoleAssignRequest> GetRoleAssignRequest(Guid id)
        {
            var userObj = await _userApiClient.GetUserById(id);

            var roleObj = await _roleApiClient.GetAllRoles();

            var roleAssignRequest = new RoleAssignRequest();
            foreach (var role in roleObj.ResultObj)
            {
                roleAssignRequest.Roles.Add(new SelectItem()
                {
                    Id = role.RoleId.ToString(),
                    Name = role.Name,
                    Selected = userObj.ResultObj.Roles.Contains(role.Name)
                });
            }
            return roleAssignRequest;
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(Guid id)
        {
            //Gửi request lấy thông tin người dùng theo id
            var result = await _userApiClient.GetUserById(id);
            return View(result.ResultObj);
        }
    }
}