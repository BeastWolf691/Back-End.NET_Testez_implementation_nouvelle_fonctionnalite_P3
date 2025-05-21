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

        [RegularExpression(@"^[a-zA-Z\p{L}\s\-()]*$", ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "NotDescription")]
        public string Description { get; set; }

        [RegularExpression(@"^[a-zA-Z\p{L}\s\-()]*$", ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "NotDetails")]
        public string Details { get; set; }

        [Required(ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "MissingPrice")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "PriceNotANumber")]
        [Range(1, double.MaxValue,ErrorMessageResourceType = typeof(ProductServiceRessources),ErrorMessageResourceName = "PriceNotGreaterThanZero")]
        public string Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "MissingStock")]
        [RegularExpression(@"^\d+$", ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "StockNotAnInteger")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(ProductServiceRessources), ErrorMessageResourceName = "StockNotGreaterThanZero")]
        public string Stock { get; set; }
    }
}
