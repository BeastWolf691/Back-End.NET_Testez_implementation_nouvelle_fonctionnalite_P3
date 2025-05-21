using System;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace P3AddNewFunctionalityDotNetCore.Resources.Models.Services
{
    public static class ProductServiceRessources
    {
        private static ResourceManager resourceManager = new ResourceManager(
  "P3AddNewFunctionalityDotNetCore.Resources.Models.Services.ProductService",
  Assembly.GetExecutingAssembly());

        private static CultureInfo resourceCulture;

        public static string MissingName
        {
            get
            {
                return resourceManager.GetString("MissingName", resourceCulture);
            }
        }
        public static string MissingPrice
        {
            get
            {
                return resourceManager.GetString("MissingPrice", resourceCulture);
            }
        }
        public static string MissingStock
        {
            get
            {
                return resourceManager.GetString("MissingStock", resourceCulture);
            }
        }
        public static string PriceNotANumber
        {
            get
            {
                return resourceManager.GetString("PriceNotANumber", resourceCulture);
            }
        }
        public static string PriceNotGreaterThanZero
        {
            get
            {
                return resourceManager.GetString("PriceNotGreaterThanZero", resourceCulture);
            }
        }
        public static string StockNotAnInteger
        {
            get
            {
                return resourceManager.GetString("StockNotAnInteger", resourceCulture);
            }
        }
        public static string StockNotGreaterThanZero
        {
            get
            {
                return resourceManager.GetString("StockNotGreaterThanZero", resourceCulture);
            }
        }
        public static string NotName
        {
            get
            {
                return resourceManager.GetString("NotName", resourceCulture);
            }
        }

        public static string NotDescription
        {
            get
            {
                return resourceManager.GetString("NotDescription", resourceCulture);
            }
        }

        public static string NotDetails
        {
            get
            {
                return resourceManager.GetString("NotDetails", resourceCulture);
            }
        }
    }
}

