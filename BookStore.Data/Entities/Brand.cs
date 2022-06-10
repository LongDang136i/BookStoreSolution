using BookStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entities
{
    public class Brand
    {
        public int BrandId { set; get; }

        public int SortOrder { set; get; }

        public bool IsShowOnHome { set; get; }

        public Status Status { set; get; }

        public List<ProductInBrand> ProductInBrands { get; set; }

        public List<BrandTranslation> BrandTranslations { get; set; }
    }
}