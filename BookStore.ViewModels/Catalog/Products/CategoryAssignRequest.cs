using BookStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int ProductId { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}