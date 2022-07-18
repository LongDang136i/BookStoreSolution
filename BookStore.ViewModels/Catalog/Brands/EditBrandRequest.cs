using BookStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Brands
{
    public class EditBrandRequest
    {
        public int BrandId { get; set; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentId { set; get; }
        public Status Status { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { set; get; }
        public string LanguageId { set; get; }
    }
}