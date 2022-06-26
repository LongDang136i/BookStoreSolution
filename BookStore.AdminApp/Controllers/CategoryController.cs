using BookStore.ApiIntegration.Interface;
using BookStore.Utilities.Constants;
using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BookStore.AdminApp.Controllers
{
    public class CategoryController : BaseController
    {
        private ICategoryApiClient _categoryApiClient;
        private IConfiguration _configuration;

        public CategoryController(ICategoryApiClient categoryApiClient, IConfiguration configuration)
        {
            _categoryApiClient = categoryApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            //Lấy Token Authorize và LanguageId
            var sessions = HttpContext.Session.GetString("Token");
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            //Tạo request
            var request = new GetCategoriesPagingRequest()
            {
                BearerToken = sessions,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };

            //Gửi request đến ApiIntergration
            var data = await _categoryApiClient.GetCategoriesPaging(request);

            //tạo ViewBag lưu từ khóa cho ô tìm kiếm
            ViewBag.Keyword = keyword;

            //Thông báo kết quả bằng TempData
            if (TempData["message"] != null)
            {
                ViewBag.SuccessMsg = TempData["message"];
            }

            //Trả về kết quả
            return View(data.ResultObj);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return View();
            }

            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            request.LanguageId = languageId;

            //gửi request đăng kí người dùng
            var result = await _categoryApiClient.CreateCategory(request);
            if (result.IsSuccessed)
            {
                TempData["message"] = result.Message;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var category = await _categoryApiClient.GetCategoryById(languageId, id);

            var editRequest = new EditCategoryRequest()
            {
                CategoryId = category.ResultObj.CategoryId,
                Name = category.ResultObj.Name,
                SeoAlias = category.ResultObj.SeoAlias,
                SeoDescription = category.ResultObj.SeoDescription,
                SeoTitle = category.ResultObj.SeoTitle,
                SortOrder = category.ResultObj.SortOrder,
                Status = category.ResultObj.Status,
                IsShowOnHome = category.ResultObj.IsShowOnHome,
                ParentId = category.ResultObj.ParentId,
                LanguageId = category.ResultObj.LanguageId,
            };
            return View(editRequest);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _categoryApiClient.EditCategory(request);
            if (result.IsSuccessed)
            {
                TempData["message"] = result.Message;
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            return View(request);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            return View(new DeleteCategoryRequest() { CategoryId = id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _categoryApiClient.DeleteCategory(request.CategoryId);
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