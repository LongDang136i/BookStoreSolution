using BookStore.Data.Entities;
using BookStore.ViewModels.System.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleVm>> GetAll()
        {
            //Lấy ra danh sách tất cả role tồn tại
            var roles = await _roleManager.Roles.Select(x => new RoleVm()
            {
                RoleId = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).ToListAsync();

            return roles;
        }
    }
}