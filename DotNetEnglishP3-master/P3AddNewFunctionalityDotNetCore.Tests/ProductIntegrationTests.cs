using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Moq;
using P3AddNewFunctionalityDotNetCore.Controllers;
using P3AddNewFunctionalityDotNetCore.Data;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Xunit;
using ProductService = P3AddNewFunctionalityDotNetCore.Models.Services.ProductService;


namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductIntegrationTests
    {
        [Fact]
        public void AddProduct_ShouldBeVisibleInClientList()
        {
            var options = new DbContextOptionsBuilder<P3Referential>()
                            .UseSqlServer("Server=.;Database=P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a;Trusted_Connection=True;MultipleActiveResultSets=true")
                            .Options;

            var config = new Mock<IConfiguration>();
            var context = new P3Referential(options, config.Object);
            var productRepository = new ProductRepository(context);

            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockLocalizer = new Mock<IStringLocalizer<ProductService>>();

            var productService = new ProductService(
                new Cart(),
                productRepository,
                mockOrderRepository.Object,
                mockLocalizer.Object
            );

            var controller = new ProductController(productService, null);

            var productViewModel = new ProductViewModel
            {
                Name = "Test Tech",
                Description = "Test Description",
                Details = "Test Details",
                Price = "10.00",
                Stock = "100"
            };

            // Act
            controller.Create(productViewModel);

            // Assert
            var addedProduct = context.Product.FirstOrDefault(p => p.Name == "Test Tech");
            Assert.NotNull(addedProduct);
            Assert.Equal("Test Tech", addedProduct.Name);
            Assert.Equal("Test Description", addedProduct.Description);
            Assert.Equal("Test Details", addedProduct.Details);
            Assert.Equal(10.00, addedProduct.Price);
            Assert.Equal(100, addedProduct.Quantity);
        }

        [Fact]
        public void DeleteProduct_ShouledBeRemovedFromClientList()
        {
            var options = new DbContextOptionsBuilder<P3Referential>()
                            .UseSqlServer("Server=.;Database=P3Referential-2f561d3b-493f-46fd-83c9-6e2643e7bd0a;Trusted_Connection=True;MultipleActiveResultSets=true")
                            .Options;
            var config = new Mock<IConfiguration>();
            var context = new P3Referential(options, config.Object);
            var productRepository = new ProductRepository(context);

            var mockOrderRepository = new Mock<IOrderRepository>();
            var mockLocalizer = new Mock<IStringLocalizer<ProductService>>();

            var productService = new ProductService(
                new Cart(),
                productRepository,
                mockOrderRepository.Object,
                mockLocalizer.Object
            );
            var controller = new ProductController(productService, null);

            //re créer un produit a supprimer
            var productViewModel = new ProductViewModel
            {
                Name = "Test Tech",
                Description = "Test Description",
                Details = "Test Details",
                Price = "10.00",
                Stock = "100"
            };
            controller.Create(productViewModel);

            var productToDelete = context.Product.FirstOrDefault(p => p.Name == "Test Tech");
            Assert.NotNull(productToDelete);

            // Act
            controller.DeleteProduct(productToDelete.Id);
            // Assert
            var deletedProduct = context.Product.FirstOrDefault(p => p.Id == productToDelete.Id);
            Assert.Null(deletedProduct);
        }
    }
}
