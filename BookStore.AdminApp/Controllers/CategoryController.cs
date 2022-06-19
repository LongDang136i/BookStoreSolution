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
            //Tạo request lấy ds Category
            var request = new GetCategoriesPagingRequest()
            {
                BearerToken = sessions,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };

            //Gửi request lấy ds người dùng
            var data = await _categoryApiClient.GetCategoriesPaging(request);

            //tạo ViewBag lưu từ khóa cho ô tìm kiếm
            ViewBag.Keyword = keyword;

            //Thông báo kết quả bằng TempData
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
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
                return View();
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            request.LanguageId = languageId;

            //gửi request đăng kí người dùng
            var result = await _categoryApiClient.CreateCategory(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Create a new User successful";
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
                Name = category.Name,
                SeoAlias = category.SeoAlias,
                SeoDescription = category.SeoDescription,
                SeoTitle = category.SeoTitle,
                SortOrder = category.SortOrder,
                Status = category.Status,
                IsShowOnHome = category.IsShowOnHome,
                ParentId = category.ParentId,
                LanguageId = languageId,
            };
            return View(editRequest);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int id, EditCategoryRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            request.LanguageId = languageId;

            var result = await _categoryApiClient.EditCategory(id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Edit category successful";
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
                return View();

            var result = await _categoryApiClient.DeleteCategory(request.CategoryId);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Delete category successful";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }
    }
}