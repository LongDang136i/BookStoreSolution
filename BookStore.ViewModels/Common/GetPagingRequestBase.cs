using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.ViewModels.Common
{
    public class GetPagingRequestBase : RequestBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Keyword { get; set; }
    }
}