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

        Task<int> Create(BrandCreateRequest request);

        Task<int> Update(BrandUpdateRequest request);

        Task<int> Delete(int BrandId);

        #endregion Admin App

        //---------------------------------------------------------------------------------//

        #region Web App

        //

        #endregion Web App

        //---------------------------------------------------------------------------------//

        #region Both Admin & Web App

        Task<List<BrandVm>> GetAll(string languageId);

        Task<BrandVm> GetById(string languageId, int brandId);

        #endregion Both Admin & Web App
    }
}