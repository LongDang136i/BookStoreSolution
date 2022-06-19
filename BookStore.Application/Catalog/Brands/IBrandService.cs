using BookStore.ViewModels.Catalog.Brands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Catalog.Brands
{
    public interface IBrandService
    {
        //---------------------------------------------------------------------------------//

        #region Admin App

        Task<int> CreateBrand(CreateBrandRequest request);

        Task<int> UpdateBrand(UpdateBrandRequest request);

        Task<int> DeleteBrand(int BrandId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<BrandVm>> GetAllBrands(string languageId);

        Task<BrandVm> GetBrandById(string languageId, int brandId);

        #endregion Both Admin & Web App
    }
}