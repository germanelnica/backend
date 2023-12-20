using DemoApp.Controllers;
using DemoApp.Data;
using DemoApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;


namespace UnitTesting
{
    public class CardBrandTest
    {
        private readonly CarBrandController _carBrandController;
        private readonly ApiDbContext _apiDbContext;
        public CardBrandTest()
        {
            
        }
        [Fact]
        public async void GoodResponse()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Corrected method
                .Options;

            using (var context = new ApiDbContext(options))
            {
                var controller = new CarBrandController(context);

                // Act
                var result = await controller.Get();

                // Assert
                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithData()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApiDbContext(options))
            {
                // Add sample data to the in-memory database
                context.CarBrand.Add(new CarBrand { Id = 1, Name = "Brand1" });
                context.SaveChanges();
            }

            using (var context = new ApiDbContext(options))
            {
                var controller = new CarBrandController(context);

                // Act
                var result = await controller.Get();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var data = Assert.IsType<List<CarBrand>>(okResult.Value);

                // Add your assertions based on the seeded data
                Assert.Single(data); // Ensure there is one item
                Assert.Equal("Brand1", data[0].Name); // Ensure the name matches
            }
        }

        [Fact]
        public void GoodResponseById()
        {
            var result = _carBrandController.Get(1);
            Assert.NotNull(result);
        }
        [Fact]
        public void BadResponse()
        {
            var result = _carBrandController.Get(1212121);
            Assert.Null(result);
        }
    }
}