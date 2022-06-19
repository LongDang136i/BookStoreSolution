using BookStore.Application.Catalog.Categories;
using BookStore.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        [HttpGet("paging")]
        [Authorize]
        public async Task<IActionResult> GetCategoriesPaging([FromQuery] GetCategoriesPagingRequest request)
        {
            var categories = await _categoryService.GetCategoriesPaging(request);
            return Ok(categories);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateCategoryRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Tạo category mới
            var result = await _categoryService.CreateCategory(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditCategory(int id, [FromBody] EditCategoryRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.CategoryId = id;

            //Thực hiện cập nhật và ktra kq
            var result = await _categoryService.EditCategory(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            //Thực hiện xóa và ktra kq
            var result = await _categoryService.DeleteCategory(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCategories(string languageId)
        {
            var categories = await _categoryService.GetAllCategories(languageId);
            return Ok(categories);
        }

        [HttpGet("{id}/{languageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryById(string languageId, int id)
        {
            var category = await _categoryService.GetCategoryById(languageId, id);
            return Ok(category);
        }

        #endregion Both Admin & Web App
    }
}