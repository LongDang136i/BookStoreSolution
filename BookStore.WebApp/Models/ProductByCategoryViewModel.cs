using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.Products;
using BookStore.ViewModels.Common;
using System.Collections.Generic;

namespace BookStore.WebApp.Models
{
    public class ProductByCategoryViewModel
    {
        public CategoryVm Category { get; set; }

        public PagedResult<ProductInfoVm> Products { get; set; }

        public List<ProductInfoVm> RelatedProducts { get; set; }
    }
}