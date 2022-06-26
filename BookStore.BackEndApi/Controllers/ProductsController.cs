using BookStore.Application.Catalog.Products;
using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.BackEndApi.Controllers
{
    //api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        [HttpGet("paging")]
        [Authorize]
        public async Task<IActionResult> GetProductsPaging([FromQuery] GetProductsPagingRequest request)
        {
            var products = await _productService.GetProductsPaging(request);
            return Ok(products);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Tạo product mới
            var result = await _productService.CreateProduct(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> EditProduct([FromRoute] int productId, [FromForm] EditProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.ProductId = productId;
            var result = await _productService.EditProduct(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            //Thực hiện xóa và ktra kq
            var result = await _productService.DeleteProduct(productId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{id}/categories")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        [HttpGet("featured/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(string languageId, int take)
        {
            //Lấy ds sản phẩm hot
            var products = await _productService.GetFeaturedProducts(languageId, take);
            if (products == null)
            {
                return BadRequest();
            }
            return Ok(products);
        }

        [HttpGet("latest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(string languageId, int take)
        {
            //Lấy ds sản phẩm mới nhất
            var products = await _productService.GetLatestProducts(languageId, take);
            if (products == null)
            {
                return BadRequest();
            }
            return Ok(products);
        }

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        [HttpGet("{productId}/{languageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById(string languageId, int productId)
        {
            var result = await _productService.GetProductById(languageId, productId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("productimages/{productId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductImageByProductId(int productId)
        {
            //Lấy ảnh theo imageId
            var result = await _productService.GetProductImageByProductId(productId);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{productId}/images/{imageId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductImageById(int productId, int imageId)
        {
            //Lấy ảnh theo imageId
            var image = await _productService.GetProductImageById(imageId);
            if (image == null)
            {
                return BadRequest();
            }
            return Ok(image);
        }

        #endregion Both Admin & Web App
    }
}