using BookStore.ApiIntegration.Interface;
using BookStore.Utilities.Constants;
using BookStore.ViewModels.Catalog.Products;
using BookStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductDetail(int id, string culture)
        {
            var product = await _productApiClient.GetProductById(culture, id);
            var result = new ProductDetailViewModel()
            {
                Product = product.ResultObj,
                Category = product.ResultObj.Categories
            };
            return View(result);
        }

        public async Task<IActionResult> ProductByCategory(int id, string culture, int pageIndex = 1)
        {
            var request = new GetProductsPagingRequest()
            {
                CategoryId = id,
                PageIndex = pageIndex,
                LanguageId = culture,
                PageSize = SystemConstants.ProductSettings.NumberOfProductPerPage,
            };
            var products = await _productApiClient.GetProductsPaging(request);

            var category = await _categoryApiClient.GetCategoryById(culture, id);
            var result = new ProductByCategoryViewModel()
            {
                Category = category.ResultObj,
                Products = products.ResultObj
            };
            return View(result);
        }
    }
}