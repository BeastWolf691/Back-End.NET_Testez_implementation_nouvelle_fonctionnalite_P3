using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Resources.Models.Services;


namespace P3AddNewFunctionalityDotNetCore.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName ="MissingName")]
        [RegularExpression(@"^[a-zA-Z\p{L}\s\-()]+$", ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "NotName")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z\s,.\-()]+$")]
        public string Description { get; set; }

        [RegularExpression(@"^[a-zA-Z\s.,\-()]+$")]
        public string Details { get; set; }

        [Required(ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "MissingPrice")]
        [Range(0.01, double.MaxValue,ErrorMessageResourceType = typeof(ProductServiceRessources),ErrorMessageResourceName = "PriceNotGreaterThanZero")]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "MissingStock")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "StockNotGreaterThanZero")]
        public int Stock { get; set; }
    }
}
