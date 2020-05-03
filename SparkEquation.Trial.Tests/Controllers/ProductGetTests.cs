using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SparkEquation.Trial.WebAPI.Controllers;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SparkEquation.Trial.Tests.Controllers
{
    [TestClass]
    public class ProductGetTests : ProductControllerTestBase
    {
        [TestMethod]
        public async Task TestGetAll()
        {
            var testService = Substitute.For<IProductsService>();
            var product1 = CreateProduct().ToModel();
            var product2 = CreateProduct().ToModel();
            testService.GetAllProductDataAsync()
                .Returns(Task.FromResult(new List<Product> { product1, product2 }));
            var controller = new ProductController(testService);
            var result = await controller.Get();
            Assert.IsTrue(result is JsonResult);
            Assert.IsTrue((result as JsonResult).Value is List<Product>);
            Assert.IsTrue(((result as JsonResult).Value as List<Product>).Count == 2);
        }

        [TestMethod]
        public async Task TestGetByIdSuccess()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.GetProductAsync(Arg.Any<int>())
                .Returns(Task.FromResult(product.ToModel()));
            var controller = new ProductController(testService);
            var result = await controller.GetById(1);
            Assert.IsTrue(result is JsonResult);
            Assert.IsTrue((result as JsonResult).Value is Product);
        }

        [TestMethod]
        public async Task TestGetByIdFailure()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.GetProductAsync(Arg.Any<int>())
                .Returns(Task.FromResult<Product>(null));
            var controller = new ProductController(testService);
            var result = await controller.GetById(1);
            Assert.IsTrue(result is NotFoundResult);
        }
    }
}
