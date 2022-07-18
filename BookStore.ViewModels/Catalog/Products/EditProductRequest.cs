using BookStore.Data.Entities;
using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.ProductImages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products
{
    public class EditProductRequest
    {
        public int ProductId { get; set; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public bool IsFeatured { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public CategoryAssignRequest CategoryAssign { get; set; } = new CategoryAssignRequest();
        public string ShowDefaultImage { set; get; }
        public List<string> ShowProductImages { get; set; } = new List<string>();
        public List<IFormFile> ProductImages { get; set; }
        public IFormFile DefaultImage { get; set; }
    }
}