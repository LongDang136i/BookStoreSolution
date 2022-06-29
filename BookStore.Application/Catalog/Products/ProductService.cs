using BookStore.Application.Common;
using BookStore.Data.EF;
using BookStore.Data.Entities;
using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using BookStore.Utilities.Constants;
using BookStore.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookStore.ViewModels.Catalog.Categories;

namespace BookStore.Application.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly bsDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public ProductService(bsDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        //---------------------------------------------------------------------------------//

        #region Private Menthod

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        #endregion Private Menthod

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<ApiResult<int>> CreateProduct(CreateProductRequest request)
        {
            //Lấy danh sách ngôn ngữ
            var languages = _context.Languages;
            var translations = new List<ProductTranslation>();

            //Chạy vòng lặp: Với mỗi ngôn ngữ có đc, so sánh với ngôn ngữ của request:
            foreach (var language in languages)
            {
                // Nếu tương ứng: đưa thông tin được nhập vào đối tượng ProductTranslation(lưu vào bảng ProductTranslation) .
                if (language.LanguageId == request.LanguageId)
                {
                    translations.Add(new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId,
                    });
                }
                // Nếu không tương ứng: tạo thông tin N/A cho đối tượng ProductTranslation cho sản phẩm đang tạo với ngôn ngữ còn lại.
                else
                {
                    translations.Add(new ProductTranslation()
                    {
                        Name = SystemConstants.DefaultValueConstant.NA,
                        Description = SystemConstants.DefaultValueConstant.NA,
                        Details = SystemConstants.DefaultValueConstant.NA,
                        SeoAlias = SystemConstants.DefaultValueConstant.NA,
                        SeoDescription = SystemConstants.DefaultValueConstant.NA,
                        SeoTitle = SystemConstants.DefaultValueConstant.NA,
                        LanguageId = language.LanguageId
                    });
                }
            }
            //Tạo mới một sản phẩm với thông tin nhập vào (lưu vào bảng Products)
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = translations,
                IsFeatured = request.IsFeatured,
            };

            //Kiểm tra xem có ảnh sản phẩm trong request không,nếu có tạo đối tượng để lưu thông tin ảnh sản phẩm
            if (request.DefaultImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Default Image",
                        DateCreated = DateTime.Now,
                        FileSize = request.DefaultImage.Length,
                        ImagePath = await this.SaveFile(request.DefaultImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }

            if (request.ProductImages != null)
            {
                foreach (var image in request.ProductImages)
                {
                    var ill = new ProductImage()
                    {
                        Caption = "Illustrating Images",
                        DateCreated = DateTime.Now,
                        FileSize = image.Length,
                        ImagePath = await this.SaveFile(image),
                        IsDefault = false,
                        SortOrder = 2
                    };
                    product.ProductImages.Add(ill);
                }
            }
            //Thêm sản phẩm vào csdl
            _context.Products.Add(product);

            if (await _context.SaveChangesAsync() > 0)
            {
                return new ApiSuccessResult<int>(product.ProductId, "Create new product successful!");
            }
            return new ApiErrorResult<int>("Can not create product");
        }

        public async Task<ApiResult<int>> EditProduct(EditProductRequest request)
        {
            //Lấy thông tin product,productTranslation theo id từ request,
            var product = await _context.Products.FindAsync(request.ProductId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(
                x => x.ProductId == request.ProductId
                && x.LanguageId == request.LanguageId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (product == null || productTranslation == null) throw new BookStoreException($"Cannot find a product with id: {request.ProductId}");

            //Nếu tìm được product, gán lại thông tin mới từ request
            productTranslation.Name = request.Name;
            productTranslation.SeoAlias = request.SeoAlias;
            productTranslation.SeoDescription = request.SeoDescription;
            productTranslation.SeoTitle = request.SeoTitle;
            productTranslation.Description = request.Description;
            productTranslation.Details = request.Details;
            product.Price = request.Price;
            product.OriginalPrice = request.OriginalPrice;
            product.Stock = request.Stock;
            product.IsFeatured = request.IsFeatured;

            //Kiểm tra nếu có cập nhật hình ảnh mới, thì lấy ra hình ảnh mặc định
            var images = await _context.ProductImages.Where(x => x.ProductId == request.ProductId && x.IsDefault == true).FirstOrDefaultAsync();

            if (request.DefaultImage != null)
            {
                images.ImagePath = await this.SaveFile(request.DefaultImage);
                images.FileSize = request.DefaultImage.Length;
            }
            if (request.ProductImages != null)
            {
                foreach (var image in request.ProductImages)
                {
                    var ill = new ProductImage()
                    {
                        Caption = "Illustrating Images",
                        DateCreated = DateTime.Now,
                        FileSize = image.Length,
                        ImagePath = await this.SaveFile(image),
                        IsDefault = false,
                        SortOrder = 2
                    };
                    product.ProductImages.Add(ill);
                }
            }
            //Thực thi
            var data = await _context.SaveChangesAsync();
            if (data >= 0)
            {
                return new ApiSuccessResult<int>(product.ProductId, "Update product information successful!");
            }
            return new ApiErrorResult<int>("Can not update product");
        }

        public async Task<ApiResult<bool>> DeleteProduct(int productId)
        {
            //Lấy thông tin product,productTranslation theo id từ request,
            var product = await _context.Products.FindAsync(productId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId);
            var productInCategory = await _context.ProductInCategories.Where(x => x.ProductId == productId).ToListAsync();
            //Ktra: nếu kết quả null thì báo lỗi
            if (product == null || productTranslation == null) return new ApiErrorResult<bool>("Product doesn't exist anymore!");

            //Lấy hình ảnh của product để xóa
            var images = _context.ProductImages.Where(i => i.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            //Xóa product và productTranslation
            _context.Products.Remove(product);
            _context.ProductTranslations.Remove(productTranslation);
            foreach (var item in productInCategory)
            {
                _context.ProductInCategories.Remove(item);
            }
            var data = await _context.SaveChangesAsync();
            if (data > 0)
            {
                return new ApiSuccessResult<bool>("Delete product successful!");
            }
            return new ApiErrorResult<bool>("Problem when delete product");
        }

        public async Task<int> RemoveProductImage(int imageId)
        {
            //Lấy ảnh ra theo imageId
            var productImage = await _context.ProductImages.FindAsync(imageId);

            //Kiểm tra null nếu và xóa ảnh
            if (productImage == null)
                throw new BookStoreException($"Cannot find an image with id {imageId}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<ApiResult<bool>> CategoryAssign(int productId, CategoryAssignRequest request)
        {
            //Lấy product theo productId, ktra null
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return new ApiErrorResult<bool>($"Product with id {productId} not exist");
            }
            //Chạy vòng lặp với mỗi category trong list Categories của request
            foreach (var category in request.Categories)
            {
                //lấy ra productInCategory theo CategoryId và ProductId
                var productInCategory = await _context.ProductInCategories
                    .FirstOrDefaultAsync(x => x.CategoryId == int.Parse(category.Id)
                    && x.ProductId == productId);

                //Nếu đã tồn tại và trạng thái hiện tại ở request == false thì xóa bản ghi khỏi bảng
                if (productInCategory != null && category.Selected == false)
                {
                    _context.ProductInCategories.Remove(productInCategory);
                }
                //Nếu chưa tồn tại và trạng thái hiện tại ở request == true thì tạo mới bản ghi
                else if (productInCategory == null && category.Selected)
                {
                    await _context.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        CategoryId = int.Parse(category.Id),
                        ProductId = productId
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        public async Task<ApiResult<List<ProductInfoVm>>> GetCollectionProducts(string languageId, int take)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.CategoryId into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.ProductId equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == languageId && pi.IsDefault == true
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Where(x => x.pt.Name.Contains("Mahouka")).Take(take)
                .Select(x => new ProductInfoVm()
                {
                    ProductId = x.p.ProductId,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    LanguageId = x.pt.LanguageId,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ShowDefaultImage = x.pi.ImagePath,
                }).ToListAsync();

            //Thực thi
            if (data != null)
            {
                return new ApiSuccessResult<List<ProductInfoVm>>(data);
            }
            return new ApiErrorResult<List<ProductInfoVm>>("Problem when get product info!");
        }

        public async Task<ApiResult<List<ProductInfoVm>>> GetFeaturedProducts(string languageId, int take)
        {
            //1. Lấy sản phẩm hot
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.CategoryId into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.ProductId equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == languageId && pi.IsDefault == true && p.IsFeatured == true
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductInfoVm()
                {
                    ProductId = x.p.ProductId,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    LanguageId = x.pt.LanguageId,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ShowDefaultImage = x.pi.ImagePath,
                }).ToListAsync();

            //Thực thi
            if (data != null)
            {
                return new ApiSuccessResult<List<ProductInfoVm>>(data);
            }
            return new ApiErrorResult<List<ProductInfoVm>>("Problem when get product info!");
        }

        public async Task<ApiResult<List<ProductInfoVm>>> GetLatestProducts(string languageId, int take)
        {
            //1. Lấy sản phẩm mới nhất
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.CategoryId into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.ProductId equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == languageId && pi.IsDefault == true
                        select new { p, pt, pic, pi };

            var data = await query.OrderByDescending(x => x.p.DateCreated).Take(take)
                .Select(x => new ProductInfoVm()
                {
                    ProductId = x.p.ProductId,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ShowDefaultImage = x.pi.ImagePath,
                }).ToListAsync();

            if (data != null)
            {
                return new ApiSuccessResult<List<ProductInfoVm>>(data);
            }
            return new ApiErrorResult<List<ProductInfoVm>>("Problem when get product info!");
        }

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<ApiResult<PagedResult<ProductInfoVm>>> GetProductsPaging(GetProductsPagingRequest request)
        {
            //1. Tạo truy vấn Join:
            /*Từ p ở bảng Products
             * join pt ở bảng ProductTranslations theo ProductId
             * join pic ở bảng ProductInCategories theo ProductId lưu vào ppic(lấy ra thông tin sản phẩm từ bảng Products, ProductTranslations, ProductInCategories theo ProductId lưu vào ppic)(chấp nhận rỗng)(lấy cả những sản phẩm chưa danh mục(chưa có trong bảng ProductInCategories))
             * join c ở bảng Categories(Lấy ra thông tin danh mục của các danh mục từ sản phẩm trên) lưu vào picc (chấp nhận rỗng)
             * join pi ở bảng ProductImages lấy ra thông tin hình ảnh có theo ProductId(chấp nhận rỗng)
             * where LanguageId ở bảng ProductTranslations == request.LanguageId và thuộc tính IsDefault của hình ảnh lưu ở pi == true
             * Lấy ra các Products: p; ProductTranslations: pt, ProductInCategories pic, ProductImages: pi
             */
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.CategoryId into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.ProductId equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId && pi.IsDefault == true
                        select new { p, pt, pic, pi };

            //2. Lọc dữ liệu
            //Nếu từ khóa khác rỗng, chỉ lấy ra những ProductTranslations có từ khóa trong tên
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            //Nếu request có CategoryId và khác 0 thì lấy ra những sản phẩm có CategoryId tương tự
            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            //3. Phân trang
            //Lấy ra tổng số bản ghi
            int totalRow = await query.CountAsync();

            //Tạo data cho từng trang, lấy ra danh sách bản ghi nhất định
            var data = await query.OrderBy(x => x.pt.Name)
                .Select(x => new ProductInfoVm()
                {
                    ProductId = x.p.ProductId,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    //ShowProductImages = productImages.Count > 0 ? productImages : new List<string>() { SystemConstants.ProductSettings.ErrorImage },
                    ShowDefaultImage = x.pi.ImagePath,
                }).ToListAsync();

            var dataSorted = data;
            if (request.SortBy != null && request.SortBy.Contains("NameDSC"))
                dataSorted = data.OrderByDescending(x => x.Name).ToList();
            if (request.SortBy != null && request.SortBy.Contains("PriceASC"))
                dataSorted = data.OrderBy(x => x.Price).ToList();
            if (request.SortBy != null && request.SortBy.Contains("PriceDSC"))
                dataSorted = data.OrderByDescending(x => x.Price).ToList();

            var result = dataSorted.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToList();
            //if (request.SortBy != null)
            //    switch (request.SortBy)
            //    {
            //        case 2:
            //            dataSorted = data.OrderByDescending(x => x.Name).ToList();
            //            break;

            //        case 3:
            //            dataSorted = data.OrderBy(x => x.Price).ToList();
            //            break;

            //        case 4:
            //            dataSorted = data.OrderByDescending(x => x.Price).ToList();
            //            break;

            //        default:
            //            dataSorted = data;
            //            break;
            //    }

            //4. Tạo trang kết quả
            var pagedResult = new PagedResult<ProductInfoVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = result
            };
            return new ApiSuccessResult<PagedResult<ProductInfoVm>>(pagedResult);
        }

        public async Task<ApiResult<ProductInfoVm>> GetProductById(string languageId, int productId)
        {
            //Lấy ra product theo productId
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ProductId equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ProductId equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.CategoryId into picc
                        from c in picc.DefaultIfEmpty()
                        join pi in _context.ProductImages on p.ProductId equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == languageId && pi.IsDefault == true
                        where p.ProductId == productId
                        select new { p, pt, pic, pi };

            //Lấy ra categories của product
            var getCategoryOfProduct = from c in _context.Categories
                                       join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                                       join pic in _context.ProductInCategories on c.CategoryId equals pic.CategoryId
                                       where pic.ProductId == productId && ct.LanguageId == languageId
                                       select new { c, ct };
            var categories = await getCategoryOfProduct.Select(x => new CategoryVm()
            {
                CategoryId = x.c.CategoryId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();

            //Lấy list category
            var getAllCategory = from c in _context.Categories
                                 join ct in _context.CategoryTranslations on c.CategoryId equals ct.CategoryId
                                 join pic in _context.ProductInCategories on c.CategoryId equals pic.CategoryId
                                 where ct.LanguageId == languageId
                                 select new { c, ct, pic };

            var listCategory = await getAllCategory.Select(x => new CategoryVm()
            {
                CategoryId = x.c.CategoryId,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
            }).ToListAsync();

            //lấy ds đường dẫn ảnh minh họa
            var images = await _context.ProductImages.Where(x => x.ProductId == productId && x.IsDefault == false).ToListAsync();

            var productImages = new List<string>();
            if (images.Count > 0)
                foreach (var image in images)
                {
                    var imgPath = image.ImagePath;
                    productImages.Add(imgPath);
                }

            var result = await query.Select(x => new ProductInfoVm()
            {
                ProductId = x.p.ProductId,
                Name = x.pt.Name,
                DateCreated = x.p.DateCreated,
                Description = x.pt.Description,
                Details = x.pt.Details,
                LanguageId = x.pt.LanguageId,
                OriginalPrice = x.p.OriginalPrice,
                Price = x.p.Price,
                SeoAlias = x.pt.SeoAlias,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount,
                IsFeatured = x.p.IsFeatured,
                Categories = categories,
                ShowProductImages = productImages.Count > 0 ? productImages : new List<string>() { SystemConstants.ProductSettings.ErrorImage },
                ShowDefaultImage = x.pi.ImagePath,
            }).FirstOrDefaultAsync();

            if (result != null)
            {
                return new ApiSuccessResult<ProductInfoVm>(result);
            }
            return new ApiErrorResult<ProductInfoVm>("Problem when get product information!");
        }

        #endregion Both Admin & Web App
    }
}