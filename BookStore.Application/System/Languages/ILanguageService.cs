using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Languages;
using BookStore.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAllLanguages();
    }
}