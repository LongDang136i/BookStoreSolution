using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "BookStoreSolutionDb";
        public const string CartSession = "CartSession";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";

            public const string Token = "Token";

            public const string BaseAddress = "BaseAddress";
        }

        public class ProductSettings
        {
            public const int NumberOfCollectionProduct = 5;
            public const int NumberOfProductPerPage = 12;
            public const int NumberOfFeaturedProducts = 3;
            public const int NumberOfLatestProducts = 8;
            public const string ErrorImage = "/user-content/error-image.jpg";
        }

        public class DefaultValueConstant
        {
            public const string NA = "N/A";
        }
    }
}