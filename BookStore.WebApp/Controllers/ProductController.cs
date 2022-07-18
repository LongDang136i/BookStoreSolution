using BookStore.ApiIntegration.Interface;
using BookStore.Utilities.Constants;
using BookStore.ViewModels.Catalog.Products;
using BookStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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

        public async Task<IActionResult> ProductByCategory(string keyword, int id, string culture, int pageIndex = 1, string? sortBy = "NameASC")
        {
            var listSortBy = new List<SelectListItem>() { };
            listSortBy.Add(new SelectListItem("Sort By: Name A-Z", "NameASC", sortBy.Equals("NameASC") ? true : false));
            listSortBy.Add(new SelectListItem("Sort By: Name Z-A", "NameDSC", sortBy.Equals("NameDSC") ? true : false));
            listSortBy.Add(new SelectListItem("Sort By: Price Ascending", "PriceASC", sortBy.Equals("PriceASC") ? true : false));
            listSortBy.Add(new SelectListItem("Sort By: Price Descending", "PriceDSC", sortBy.Equals("PriceDSC") ? true : false));
            ViewBag.SortBy = listSortBy;

            var request = new GetProductsPagingRequest()
            {
                Keyword = keyword,
                SortBy = sortBy,
                CategoryId = id,
                PageIndex = pageIndex,
                LanguageId = culture,
                PageSize = SystemConstants.ProductSettings.NumberOfProductPerPage,
            };
            var products = await _productApiClient.GetProductsPaging(request);
            var listcategory = await _categoryApiClient.GetAllCategories(culture);
            var category = await _categoryApiClient.GetCategoryById(culture, id);
            var result = new ProductByCategoryViewModel()
            {
                ListCategory = listcategory.ResultObj,
                Category = category.ResultObj,
                Products = products.ResultObj
            };
            return View(result);
        }
    }
}