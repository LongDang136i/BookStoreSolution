using BookStore.ApiIntegration.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace BookStore.WebApp.Controllers.Components
{
    public class MenuBarViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public MenuBarViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryApiClient.GetAllCategories(CultureInfo.CurrentCulture.Name);
            return View(items.ResultObj);
        }
    }
}