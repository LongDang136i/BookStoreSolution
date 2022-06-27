using BookStore.ViewModels.Catalog.Categories;
using BookStore.ViewModels.Catalog.Products;

namespace BookStore.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryVm Category { get; set; }

        public ProductInfoVm Product { get; set; }
    }
}