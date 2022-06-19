using BookStore.ViewModels.Common;
using System.Collections.Generic;

namespace BookStore.ViewModels.Catalog.Products
{
    public class GetProductsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}