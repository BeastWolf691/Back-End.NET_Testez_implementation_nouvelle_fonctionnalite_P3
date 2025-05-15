using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P3AddNewFunctionalityDotNetCore.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "MissingName")]
        [RegularExpression(@"^[a-zA-Z\s.,;:!?()]+$", ErrorMessage = "InvalidName")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z\s.,;:!?()]+$", ErrorMessage = "InvalidDescription")]
        public string Description { get; set; }

        [RegularExpression(@"^[a-zA-Z\s.,;:!?()]+$", ErrorMessage = "InvalidDetails")]
        public string Details { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "QuantityNotGreaterThanZero")]
        public int Stock { get; set; }
    }
}
