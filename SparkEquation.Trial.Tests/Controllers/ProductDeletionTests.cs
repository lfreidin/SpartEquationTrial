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
    public class ProductDeletionTests
    {
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

    }
}
