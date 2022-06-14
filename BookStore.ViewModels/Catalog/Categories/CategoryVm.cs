using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Categories
{
    public class CategoryVm
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}