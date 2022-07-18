using BookStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Catalog.Categories
{
    public class GetCategoriesPagingRequest : GetPagingRequestBase
    {
        public string LanguageId { get; set; }
    }
}