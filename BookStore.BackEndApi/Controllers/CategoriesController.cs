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
            //Gửi request đến Application
            var result = await _categoryService.GetCategoriesPaging(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Gửi request đến Application
            var result = await _categoryService.CreateCategory(request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> EditCategory([FromBody] EditCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Gửi request đến Application
            var result = await _categoryService.EditCategory(request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            //Gửi request đến Application
            var result = await _categoryService.DeleteCategory(categoryId);

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
            //Gửi request đến Application
            var result = await _categoryService.GetAllCategories(languageId);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{categoryId}/{languageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryById(string languageId, int categoryId)
        {
            //Gửi request đến Application
            var result = await _categoryService.GetCategoryById(languageId, categoryId);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        #endregion Both Admin & Web App
    }
}