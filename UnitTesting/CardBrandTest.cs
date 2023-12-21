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

        private readonly DbContextOptions<ApiDbContext> options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseNpgsql("User Id=postgres;Password=postgres;Server=localhost;Port=5433;Database=SampleDb;Pooling=true;") // Provide your test database connection string
                .Options;
        public CardBrandTest()
        {
            
        }

        [Fact]
        public async void GoodResponse()
        {
            
            using (var context = new ApiDbContext(options))
            {
                var controller = new CarBrandController(context);
                var result = await controller.Get();
                // Act
                var okResult = Assert.IsType<OkObjectResult>(result);
                var data = Assert.IsType<List<CarBrand>>(okResult.Value);

                // Additional assertions based on the seeded data
                Assert.NotEmpty(data);
            }
        }


        [Fact]
        public async void GoodResponseById()
        {
            using (var context = new ApiDbContext(options))
            {
                var controller = new CarBrandController(context);

                // Act
                var result = await controller.Get(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var data = Assert.IsType<CarBrand>(okResult.Value);

                // Add your assertions based on the seeded data
                Assert.NotNull(data);
            }
        }
        [Fact]
        public async void BadResponse()
        {
            using (var context = new ApiDbContext(options))
            {
                var controller = new CarBrandController(context);

                // Act // not exist
                var result = await controller.Get(112121121);

                // Assert
                var notFoundResult = Assert.IsType<NotFoundResult>(result);

                // Additional assertions if needed
                Assert.Equal(404, notFoundResult.StatusCode);
            }
        }
    }
}