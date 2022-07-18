using BookStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entities
{
    public class Category
    {
        public int CategoryId { set; get; }

        public int SortOrder { set; get; }

        public bool IsShowOnHome { set; get; }

        public int? ParentId { set; get; }

        public Status Status { set; get; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}