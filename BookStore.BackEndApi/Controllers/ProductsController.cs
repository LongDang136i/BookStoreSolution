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

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Tạo mới product và ktra kq
            var productId = await _productService.CreateProduct(request);
            if (productId == 0)
                return BadRequest();

            //Lấy product vừa tạo theo productId
            var product = await _productService.GetProductById(productId, request.LanguageId);

            //Trả về Status Code 201: Created
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, product);
        }

        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromForm] ProductUpdateRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.ProductId = productId;

            //Thực hiện cập nhật và ktra kq
            var affectedResult = await _productService.UpdateProduct(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            //Thực hiện xóa và ktra kq
            var affectedResult = await _productService.DeleteProduct(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost("{productId}/images")]
        [Authorize]
        public async Task<IActionResult> CreateProductImage(int productId, [FromForm] CreateProductImageRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Thực hiện thêm ảnh và ktra kq
            var imageId = await _productService.CreateProductImage(productId, request);
            if (imageId == 0)
            {
                return BadRequest();
            }

            //Lấy ra image theo imageId vừa tạo, trả về Statuscode 201: Created
            var image = await _productService.GetProductImageById(imageId);

            return CreatedAtAction(nameof(GetProductImageById), new { id = imageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> UpdateProductImage(int imageId, [FromForm] UpdateProductImageRequest request)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Cập nhật ảnh và ktra
            var result = await _productService.UpdateProductImage(imageId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> DeleteProductImage(int imageId)
        {
            //Ktra dữ liệu vào
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Xóa ảnh và ktra
            var result = await _productService.RemoveProductImage(imageId);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
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
        public async Task<IActionResult> GetProductById(int productId, string languageId)
        {
            var product = await _productService.GetProductById(productId, languageId);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProductPaging([FromQuery] GetProductsPagingRequest request)
        {
            var products = await _productService.GetProductsPaging(request);
            if (products == null)
            {
                return BadRequest();
            }
            return Ok(products);
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