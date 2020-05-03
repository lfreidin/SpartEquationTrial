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
    public class ProductCreationTests : ProductControllerTestBase
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
            product.ExpirationDate = DateTime.Now;
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
            product.BrandId = 1000;
            var result = await controller.Create(product);
            CheckValidationErrors(result, nameof(product.BrandId));
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

    }
}
