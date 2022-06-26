using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.ProductImages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products
{
    public class ProductDetailVm
    {
        public int ProductId { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public bool IsFeatured { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public List<CategoryVm> Categories { set; get; } = new List<CategoryVm>();
        public CategoryAssignRequest CategoryAssign { get; set; } = new CategoryAssignRequest();
        public string ShowDefaultImage { set; get; }
        public List<string> ShowProductImages { get; set; } = new List<string>();
    }
}