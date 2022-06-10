using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entities
{
    public class BrandTranslation
    {
        public int BrandTrId { set; get; }
        public int BrandId { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }

        public Brand Brand { get; set; }

        public Language Language { get; set; }
    }
}