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

        Task<int> CreateBrand(BrandCreateRequest request);

        Task<int> UpdateBrand(BrandUpdateRequest request);

        Task<int> DeleteBrand(int BrandId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<BrandVm>> GetAllBrand(string languageId);

        Task<BrandVm> GetBrandById(string languageId, int brandId);

        #endregion Both Admin & Web App
    }
}