using BookStore.Application.System.Users;
using BookStore.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookStore.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        //http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        [Authorize]
        public async Task<IActionResult> GetUsersPaging([FromQuery] GetUsersPagingRequest request)
        {
            //Lấy ds người dùng
            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }

        //PUT: http://localhost/api/users/id
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditUser(Guid id, [FromBody] EditUserRequest request)
        {
            //Kiểm tra dữ liệu vào
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Chỉnh sửa thông tin người dùng
            var result = await _userService.EditUser(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            //Xóa sửa thông tin người dùng theo id
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        [Authorize]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            //Kiểm tra dữ liệu vào
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            //Kiểm tra dữ liệu vào
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Lấy dữ liệu bằng cách gọi đến Application (UserService)
            var result = await _userService.Authenticate(request);

            //Ktra kết quả
            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            //Kiểm tra dữ liệu vào
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Tạo người dùng mới
            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            //Lấy thông tin người dùng theo id
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        #endregion Both Admin & Web App
    }
}