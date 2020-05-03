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
    public class ProductUpdateTests : ProductControllerTestBase
    {
        [TestMethod]
        public async Task TestUpdateSuccess()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.UpdateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            testService.CheckCategories(Arg.Any<List<int>>())
                .Returns(true);
            var controller = new ProductController(testService);
            var jsonResult = (JsonResult)(await controller.Update(product));
            var result = jsonResult.Value;
            Assert.IsTrue(jsonResult.Value is Product);
        }

        [TestMethod]
        public async Task TestUpdateFailure()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.UpdateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult<Product>(null));
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            testService.CheckCategories(Arg.Any<List<int>>())
                .Returns(true);
            var controller = new ProductController(testService);
            var result = (await controller.Update(product));
            Assert.IsTrue(result is NotFoundResult);
        }

        [TestMethod]
        public async Task TestUpdateRequired()
        {
            var testService = Substitute.For<IProductsService>();
            testService.UpdateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult<Product>(null));
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            testService.CheckCategories(Arg.Any<List<int>>())
                .Returns(true);
            var controller = new ProductController(testService);
            var product = CreateProduct();
            product.ItemsInStock = null;
            product.Featured = null;
            product.Rating = null;
            product.BrandId = null;
            var result = (await controller.Update(product));
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.IsTrue((result as BadRequestObjectResult).Value is SerializableError);
            var serializableError = ((result as BadRequestObjectResult).Value as SerializableError);
            Assert.IsTrue(serializableError.Count == 4);
            Assert.IsTrue(serializableError.ContainsKey(nameof(product.BrandId)));
            Assert.IsTrue(serializableError.ContainsKey(nameof(product.ItemsInStock)));
            Assert.IsTrue(serializableError.ContainsKey(nameof(product.Featured)));
            Assert.IsTrue(serializableError.ContainsKey(nameof(product.Rating)));
        }

        [TestMethod]
        public async Task TestWrongExpirationDateWhenUpdate()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.UpdateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            var controller = new ProductController(testService);
            product.ExpirationDate = DateTime.Now;
            var result = await controller.Update(product);
            CheckValidationErrors(result, nameof(product.ExpirationDate));
        }

    }
}
