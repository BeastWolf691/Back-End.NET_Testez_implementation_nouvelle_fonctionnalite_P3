using System.Collections.Generic;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System;
using P3AddNewFunctionalityDotNetCore.Models.Services;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        private class MockProductViewModel
        {
            [Required(ErrorMessage = "MissingName")]
            public string Name { get; set; }

            public string Description { get; set; }

            public string Details { get; set; }

            [Range(0.01, double.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
            public decimal Price { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "QuantityNotGreaterThanZero")]
            public int Stock { get; set; }
        }

        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary>
        [Fact]
        public void ProductViewModel_ShouldBeValid_WhenAllFieldsCorrect()
        {
            // Arrange
            var product = new MockProductViewModel
            {
                Name = "Valid Product",
                Description = "",
                Details = "",
                Price = 19.99m,
                Stock = 10
            };
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenPriceIsZero()
        {
            // Arrange
            var product = new MockProductViewModel
            {
                Name = "Valid Product",
                Description = "",
                Details = "",
                Price = 0m,
                Stock = 10
            };
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(product, context, results, true);

            // 🔍 Debug : Affiche les erreurs s'il y en a
            if (results.Count == 0)
            {
                Console.WriteLine("Aucune erreur de validation retournée.");
            }
            else
            {
                foreach (var error in results)
                {
                    Console.WriteLine("Erreur trouvée : " + error.ErrorMessage);
                }
            }

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null && r.ErrorMessage.Contains("PriceNotGreaterThanZero"));
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenNameIsMissing()
        {
            var product = new MockProductViewModel
            {
                Name = "",
                Price = 10m,
                Stock = 5
            };
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(product, context, results, true);

            // 🔍 Debug : Affiche les erreurs s'il y en a
            if (results.Count == 0)
            {
                Console.WriteLine("Aucune erreur de validation retournée.");
            }
            else
            {
                foreach (var error in results)
                {
                    Console.WriteLine("Erreur trouvée : " + error.ErrorMessage);
                }
            }
            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null && r.ErrorMessage.Contains("MissingName"));
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenStockIsZero()
        {
            var product = new MockProductViewModel
            {
                Name = "Test",
                Price = 10m,
                Stock = 0
            };
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(product, context, results, true);

            // 🔍 Debug : Affiche les erreurs s'il y en a
            if (results.Count == 0)
            {
                Console.WriteLine("Aucune erreur de validation retournée.");
            }
            else
            {
                foreach (var error in results)
                {
                    Console.WriteLine("Erreur trouvée : " + error.ErrorMessage);
                }
            }
            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage != null && r.ErrorMessage.Contains("QuantityNotGreaterThanZero"));
        }

    }
}

// TODO write test methods to ensure a correct coverage of all possibilities

