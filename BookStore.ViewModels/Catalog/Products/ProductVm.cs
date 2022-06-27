using BookStore.Data.Entities;
using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.ProductImages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products
{
    public class ProductVm
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
        public CategoryVm Categories { set; get; }
        public CategoryAssignRequest CategoryAssign { get; set; } = new CategoryAssignRequest();
        public ProductImageVm ShowDefaultImage { set; get; } = new ProductImageVm();
        public List<ProductImageVm> ShowProductImages { get; set; } = new List<ProductImageVm>();
        public List<IFormFile> AddImages { get; set; }
        public IFormFile ChangeDefaultImage { get; set; }
        public List<IFormFile> ProductImages { get; set; }
        public IFormFile DefaultImage { get; set; }
    }
}