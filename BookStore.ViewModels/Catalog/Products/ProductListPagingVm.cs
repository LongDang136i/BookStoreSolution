using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.ProductImages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products
{
    public class ProductListPagingVm
    {
        public int ProductId { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public int Stock { set; get; }
        public bool IsFeatured { set; get; }
        public string Description { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        //public List<CategoryVm> Categories { set; get; } = new List<CategoryVm>();
        //public CategoryAssignRequest CategoryAssign { get; set; }
        public ProductImageVm ShowDefaultImage { set; get; }
    }
}