using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "BookStoreSolutionDb";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";

            public const string Token = "Token";

            public const string BaseAddress = "BaseAddress";
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 8;
            public const int NumberOfLatestProducts = 12;
        }

        public class DefaultValueConstant
        {
            public const string NA = "N/A";
        }
    }
}