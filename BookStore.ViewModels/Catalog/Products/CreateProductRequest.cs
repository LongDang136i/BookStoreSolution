using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products
{
    public class CreateProductRequest
    {
        public int ProductId { get; set; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public bool IsFeatured { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public IFormFile DefaultImage { set; get; }
        public List<IFormFile> ProductImages { get; set; }
        public CategoryAssignRequest CategoryAssign { get; set; } = new CategoryAssignRequest();
    }
}