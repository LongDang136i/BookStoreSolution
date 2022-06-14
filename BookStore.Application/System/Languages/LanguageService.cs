using BookStore.Data.EF;
using BookStore.Data.Entities;
using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Languages;
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

namespace BookStore.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly bsDbContext _context;

        public LanguageService(bsDbContext context,
            IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            //Lấy ra danh sách tất cả language tồn tại
            var languages = await _context.Languages.Select(x => new LanguageVm()
            {
                LanguageId = x.LanguageId,
                Name = x.Name
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}