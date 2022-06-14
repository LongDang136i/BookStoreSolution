using BookStore.ViewModels.Common;
using BookStore.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ApiIntegration.Interface
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}