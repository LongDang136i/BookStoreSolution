using BookStore.Application.Catalog.Categories;
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCategory(string languageId)
        {
            var categories = await _categoryService.GetAllCategory(languageId);
            return Ok(categories);
        }

        [HttpGet("{id}/{languageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryById(string languageId, int id)
        {
            var category = await _categoryService.GetCategoryById(languageId, id);
            return Ok(category);
        }
    }
}