using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SparkEquation.Trial.WebAPI;
using SparkEquation.Trial.WebAPI.Controllers;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkEquation.Trial.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public async Task TestCreateSuccess()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.CreateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            testService.CheckCategories(Arg.Any<List<int>>())
                .Returns(true);
            var controller = new ProductController(testService);
            var result = await controller.Create(product);
            var productResult = ((JsonResult)result).Value;
            Assert.IsTrue(productResult is Product);
        }

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
        public async Task TestWrongExpirationDate()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.CreateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            testService.CheckCategories(Arg.Any<List<int>>())
                .Returns(true);
            var controller = new ProductController(testService);
            product.ExpirationDate=DateTime.Now;
            var result = await controller.Create(product);
            CheckValidationErrors(result, nameof(product.ExpirationDate));
        }

        [TestMethod]
        public async Task TestWrongBrand()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.CreateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            var controller = new ProductController(testService);
            product.BrandId=1000;
            var result = await controller.Create(product);
            CheckValidationErrors(result, nameof(product.BrandId));
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


        [TestMethod]
        public async Task TestNoProductCategories()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.CreateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            var controller = new ProductController(testService);
            product.CategoryProducts.Clear();
            var result = await controller.Create(product);
            CheckValidationErrors(result, nameof(product.CategoryProducts));
        }

        [TestMethod]
        public async Task TestTooManyCategories()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.CreateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            var controller = new ProductController(testService);
            product.CategoryProducts.Add(2);
            product.CategoryProducts.Add(3);
            product.CategoryProducts.Add(4);
            product.CategoryProducts.Add(5);
            product.CategoryProducts.Add(6);
            var result = await controller.Create(product);
            CheckValidationErrors(result, nameof(product.CategoryProducts));
        }

        [TestMethod]
        public async Task TestInvalidCategories()
        {
            var testService = Substitute.For<IProductsService>();
            var product = CreateProduct();
            testService.CreateAsync(Arg.Any<Product>())
                .Returns(Task.FromResult(product.ToModel()));
            testService.CheckCategories(Arg.Any<List<int>>())
                .Returns(false);
            testService.CheckBrand(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            var controller = new ProductController(testService);
            product.CategoryProducts.Add(1000);
            var result = await controller.Create(product);
            CheckValidationErrors(result, nameof(product.CategoryProducts));
        }



        private static void CheckValidationErrors(IActionResult result, string fieldName)
        {
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.IsTrue((result as BadRequestObjectResult).Value is SerializableError);
            Assert.IsTrue(((result as BadRequestObjectResult).Value as SerializableError).Count == 1);
            Assert.IsTrue(((result as BadRequestObjectResult).Value as SerializableError).ContainsKey(fieldName));
        }

        private ProductDto CreateProduct()
        {
            var product = new ProductDto();
            product.Id = 1000;
            product.Name = "Test product";
            product.ItemsInStock = 10;
            product.Rating = 5;
            product.ReceiptDate = new System.DateTime(2020, 1, 1);
            product.BrandId = 1;
            product.Featured = false;
            product.CategoryProducts = new List<int>() { 1 };
            product.ExpirationDate = DateTime.Now.AddDays(50);
            return product;
        }

        [TestMethod]
        public async Task TestDeleteSuccess()
        {
            var testService = Substitute.For<IProductsService>();
            testService.DeleteAsync(Arg.Any<int>())
                .Returns(Task.FromResult(true));
            var controller = new ProductController(testService);
            var result = await controller.Delete(1);
            Assert.IsTrue(result is OkResult);
        }

        [TestMethod]
        public async Task TestDeleteFailure()
        {
            var testService = Substitute.For<IProductsService>();
            testService.DeleteAsync(Arg.Any<int>())
                .Returns(Task.FromResult(false));
            var controller = new ProductController(testService);
            var result = await controller.Delete(1);
            Assert.IsTrue(result is NotFoundResult);
        }

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
