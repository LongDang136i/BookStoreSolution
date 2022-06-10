using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entities
{
    public class ProductInBrand
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }
    }
}