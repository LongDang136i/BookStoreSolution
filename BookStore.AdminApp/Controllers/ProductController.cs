using BookStore.AdminApp.Models;
using BookStore.ApiIntegration.Interface;
using BookStore.Utilities.Constants;
using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AdminApp.Controllers
{
    public class ProductController : BaseController
    {
        private IProductApiClient _productApiClient;
        private IConfiguration _configuration;
        private ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, IConfiguration configuration, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 5)
        {
            //Lấy Token Authorize và LanguageId
            var sessions = HttpContext.Session.GetString("Token");
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            //Tạo request
            var request = new GetProductsPagingRequest()
            {
                BearerToken = sessions,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
            };

            //Gửi request
            var data = await _productApiClient.GetProductsPaging(request);

            //tạo ViewBag lưu từ khóa cho ô tìm kiếm
            ViewBag.Keyword = keyword;

            var categories = await _categoryApiClient.GetAllCategories(languageId);
            ViewBag.Categories = categories.ResultObj.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.CategoryId.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.CategoryId
            });
            //Thông báo kết quả bằng TempData
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            //Trả về kết quả
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            //var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            //var categoryObj = await _categoryApiClient.GetAllCategories(languageId);

            //var categoryAssignRequest = new CategoryAssignRequest() { };

            //foreach (var cat in categoryObj.ResultObj)
            //{
            //    categoryAssignRequest.Categories.Add(new SelectItem()
            //    {
            //        Id = cat.CategoryId.ToString(),
            //        Name = cat.Name,
            //        Selected = false,
            //    });
            //}
            return View(/*new CreateProductRequest() { CategoryAssign = categoryAssignRequest }*/);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
                return View();

            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            request.LanguageId = languageId;

            //gửi request
            var result = await _productApiClient.CreateProduct(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var product = await _productApiClient.GetProductById(languageId, id);

            var categoryObj = await _categoryApiClient.GetAllCategories(languageId);

            var categoryAssignRequest = new CategoryAssignRequest() { };

            foreach (var cat in categoryObj.ResultObj)
            {
                categoryAssignRequest.ProductId = id;
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = cat.CategoryId.ToString(),
                    Name = cat.Name,
                    Selected = false,
                });
            }
            if (product.ResultObj.Categories != null)
                foreach (var catOfProduct in product.ResultObj.Categories)
                {
                    foreach (var cat in categoryAssignRequest.Categories)
                    {
                        if (catOfProduct.CategoryId == int.Parse(cat.Id))
                            cat.Selected = true;
                    }
                }
            var editRequest = new EditProductRequest()
            {
                ProductId = product.ResultObj.ProductId,
                IsFeatured = product.ResultObj.IsFeatured,
                OriginalPrice = product.ResultObj.OriginalPrice,
                Price = product.ResultObj.Price,
                Details = product.ResultObj.Details,
                Description = product.ResultObj.Description,
                Name = product.ResultObj.Name,
                SeoAlias = product.ResultObj.SeoAlias,
                SeoDescription = product.ResultObj.SeoDescription,
                SeoTitle = product.ResultObj.SeoTitle,
                Stock = product.ResultObj.Stock,
                LanguageId = languageId,
                CategoryAssign = categoryAssignRequest,
                ShowDefaultImage = product.ResultObj.ShowDefaultImage,
                ShowProductImages = product.ResultObj.ShowProductImages,
            };

            return View(editRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> EditProduct([FromForm] EditProductRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);
            request.ShowDefaultImage = "Error";
            //var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            //request.LanguageId = languageId;
            //request.ShowProductImages = new List<ProductImageVm>();
            var result = await _productApiClient.EditProduct(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            return View(new DeleteProductRequest() { ProductId = id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(DeleteProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _productApiClient.DeleteProduct(request.ProductId);
            if (result.IsSuccessed)
            {
                TempData["message"] = result.Message;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}