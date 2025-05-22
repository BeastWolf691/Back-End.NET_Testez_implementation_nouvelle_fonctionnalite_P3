using System.Collections.Generic;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using P3AddNewFunctionalityDotNetCore.Resources.Models.Services;
using System;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        private List<ValidationResult> ValidateModel(ProductViewModel model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }
        private void DisplayValidationResults(List<ValidationResult> results)
        {
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
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenPriceIsNegative()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un prix négatif.");
            var product = new ProductViewModel
            {
                Name = "Valid Product",
                Description = "",
                Details = "",
                Price = "-10",
                Stock = "10"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.PriceNotANumber);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenPriceIsZero()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un prix égal à zéro.");
            var product = new ProductViewModel
            {
                Name = "Valid Product",
                Description = "",
                Details = "",
                Price = "0",
                Stock = "10"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.PriceNotGreaterThanZero);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenPriceIsMissing()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un prix manquant.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "",
                Price = null, // champ requis manquant
                Stock = "5"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.MissingPrice);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenPriceIsNotDecimal()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un prix non décimal.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "",
                Price = "5.001", // trop de décimales
                Stock = "5"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.PriceNotANumber);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenNameIsMissing()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un nom manquant.");
            var product = new ProductViewModel
            {
                Name = "",
                Description = "",
                Details = "",
                Price = "10",
                Stock = "5"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.MissingName);
        }

        [Fact]
        public void ProductViewModel_ShouldBeValid_WithCorrectData()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec des données correctes.");
            var product = new ProductViewModel
            {
                Name = "Nom Produit",
                Description = "Ceci est une description",
                Details = "Détails optionnels",
                Price = "25.50",
                Stock = "5"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Empty(results);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenStockIsNotInteger()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un stock non entier.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "",
                Price = "10",
                Stock = "abc"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.StockNotAnInteger);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenStockIsNegative()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un stock négatif.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "",
                Price = "10",
                Stock = "-5"
            };
            var results = ValidateModel(product);
            DisplayValidationResults(results);
            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.StockNotAnInteger);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenStockIsZero()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un stock égal à zéro.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "",
                Price = "10",
                Stock = "0"
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.StockNotGreaterThanZero);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenStockIsMissing()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un stock manquant.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "",
                Price = "10",
                Stock = null
            };

            var results = ValidateModel(product);
            DisplayValidationResults(results);

            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.MissingStock);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenNameContainsSpecialCharacters()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec un nom contenant des caractères spéciaux.");
            var product = new ProductViewModel
            {
                Name = "Produit@123",
                Description = "",
                Details = "",
                Price = "10",
                Stock = "5"
            };
            var results = ValidateModel(product);
            DisplayValidationResults(results);
            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.NotName);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenDescriptionContainsSpecialCharacters()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec une description contenant des caractères spéciaux.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "Ceci est une description@123",
                Details = "",
                Price = "10",
                Stock = "5"
            };
            var results = ValidateModel(product);
            DisplayValidationResults(results);
            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.NotDescription);
        }

        [Fact]
        public void ProductViewModel_ShouldBeInvalid_WhenDetailsContainsSpecialCharacters()
        {
            Console.WriteLine("Test de validation du modèle ProductViewModel avec des détails contenant des caractères spéciaux.");
            var product = new ProductViewModel
            {
                Name = "Produit",
                Description = "",
                Details = "Détails@123",
                Price = "10",
                Stock = "5"
            };
            var results = ValidateModel(product);
            DisplayValidationResults(results);
            Assert.Contains(results, r => r.ErrorMessage == ProductServiceRessources.NotDetails);
        }
    }
}
