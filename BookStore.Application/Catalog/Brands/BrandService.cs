using BookStore.Data.EF;
using BookStore.ViewModels.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStore.Data.Entities;
using BookStore.Utilities.Constants;
using BookStore.Utilities.Exceptions;

namespace BookStore.Application.Catalog.Brands
{
    public class BrandService : IBrandService
    {
        private readonly bsDbContext _context;

        public BrandService(bsDbContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------//

        #region Admin App

        public async Task<int> CreateBrand(CreateBrandRequest request)
        {
            //Lấy danh sách ngôn ngữ
            var languages = _context.Languages;
            var translations = new List<BrandTranslation>();

            //Chạy vòng lặp: Với mỗi ngôn ngữ có đc, so sánh với ngôn ngữ của request: tạo BrandTranslation với ngôn ngữ tương ứng
            foreach (var language in languages)
            {
                if (language.LanguageId == request.LanguageId)
                {
                    translations.Add(new BrandTranslation()
                    {
                        Name = request.Name,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        SeoAlias = request.SeoAlias,
                        LanguageId = language.LanguageId,
                    });
                }
                else
                {
                    translations.Add(new BrandTranslation()
                    {
                        Name = SystemConstants.DefaultValueConstant.NA,
                        SeoDescription = SystemConstants.DefaultValueConstant.NA,
                        SeoAlias = SystemConstants.DefaultValueConstant.NA,
                        SeoTitle = SystemConstants.DefaultValueConstant.NA,
                        LanguageId = language.LanguageId
                    });
                }
            }
            //Tạo mới một brand với thông tin nhập vào (lưu vào bảng Brands)
            var brand = new Brand()
            {
                SortOrder = request.SortOrder,
                Status = request.Status,
                IsShowOnHome = request.IsShowOnHome,
                BrandTranslations = translations
            };

            //Thêm brand vào csdl
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand.BrandId;
        }

        public async Task<int> UpdateBrand(EditBrandRequest request)
        {
            //Lấy thông tin brand,brandTranslation theo id từ request,
            var brand = await _context.Brands.FindAsync(request.BrandId);
            var brandTranslation = await _context.BrandTranslations.FirstOrDefaultAsync(
                x => x.BrandId == request.BrandId
                && x.LanguageId == request.LanguageId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (brand == null || brandTranslation == null) throw new BookStoreException($"Cannot find a category with id: {request.BrandId}");

            //Nếu tìm được brand, gán lại thông tin mới từ request
            brand.Status = request.Status;
            brand.SortOrder = request.SortOrder;
            brand.IsShowOnHome = request.IsShowOnHome;
            brandTranslation.Name = request.Name;
            brandTranslation.SeoAlias = request.SeoAlias;
            brandTranslation.SeoDescription = request.SeoDescription;
            brandTranslation.SeoTitle = request.SeoTitle;

            //Thực thi
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteBrand(int brandId)
        {
            //Lấy thông tin brand,brandTranslation theo id từ request,
            var brand = await _context.Brands.FindAsync(brandId);
            var brandTranslation = await _context.BrandTranslations.FirstOrDefaultAsync(x => x.BrandId == brandId);

            //Ktra: nếu kết quả null thì báo lỗi
            if (brand == null || brandTranslation == null) throw new BookStoreException($"Cannot find a brand: {brandId}");

            //Xóa cả brand, brandTranslation
            _context.Brands.Remove(brand);
            _context.BrandTranslations.Remove(brandTranslation);

            return await _context.SaveChangesAsync();
        }

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        //

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        public async Task<List<BrandVm>> GetAllBrands(string languageId)
        {
            //1.Select join
            var query = from c in _context.Brands
                        join ct in _context.BrandTranslations on c.BrandId equals ct.BrandId
                        where ct.LanguageId == languageId
                        select new { c, ct };

            return await query.Select(x => new BrandVm()
            {
                BrandId = x.c.BrandId,
                Name = x.ct.Name
            }).ToListAsync();
        }

        public async Task<BrandVm> GetBrandById(string languageId, int brandId)
        {
            var query = from c in _context.Brands
                        join ct in _context.BrandTranslations on c.BrandId equals ct.BrandId
                        where ct.LanguageId == languageId && c.BrandId == brandId
                        select new { c, ct };
            return await query.Select(x => new BrandVm()
            {
                BrandId = x.c.BrandId,
                Name = x.ct.Name
            }).FirstOrDefaultAsync();
        }

        #endregion Both Admin & Web App
    }
}