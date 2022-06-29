using BookStore.ApiIntegration.Interface;
using BookStore.Utilities.Constants;
using BookStore.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly ISharedCultureLocalizer _loc;
        private readonly IProductApiClient _productApiClient;

        public HomeController(ILogger<HomeController> logger,
            IProductApiClient productApiClient)
        {
            _logger = logger;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentCulture.Name;

            var viewModel = new HomeViewModel();
            var featuredProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts);
            if (featuredProducts.IsSuccessed)
            {
                viewModel.FeaturedProducts = featuredProducts.ResultObj;
            }
            var latestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts);
            if (latestProducts.IsSuccessed)
            {
                viewModel.LatestProducts = latestProducts.ResultObj;
            }
            var collectionProducts = await _productApiClient.GetCollectionProducts(culture, SystemConstants.ProductSettings.NumberOfCollectionProduct);
            if (collectionProducts.IsSuccessed)
            {
                viewModel.CollectionProducts = collectionProducts.ResultObj;
            }
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}