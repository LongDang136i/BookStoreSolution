using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.ProductImages;
using BookStore.ViewModels.Catalog.Products;
using System.Collections.Generic;

namespace BookStore.AdminApp.Models
{
    public class EditProductViewModel
    {
        public EditProductRequest Request { get; set; }

        public ProductImageVm DefaultImage { get; set; }

        public List<ProductImageVm> ProductImages { get; set; }

        public List<CategoryVm> Categories { get; set; }
    }
}