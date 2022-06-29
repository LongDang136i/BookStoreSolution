using BookStore.ViewModels.Catalog.Products;
using System.Collections.Generic;

namespace BookStore.WebApp.Models
{
    public class HomeViewModel
    {
        public List<ProductInfoVm> FeaturedProducts { get; set; }

        public List<ProductInfoVm> LatestProducts { get; set; }

        public List<ProductInfoVm> CollectionProducts { get; set; }
    }
}