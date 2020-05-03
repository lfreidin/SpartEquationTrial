using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.WebAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SparkEquation.Trial.Tests.Controllers
{
    public class ProductControllerTestBase
    {
        protected static void CheckValidationErrors(IActionResult result, string fieldName)
        {
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.IsTrue((result as BadRequestObjectResult).Value is SerializableError);
            Assert.IsTrue(((result as BadRequestObjectResult).Value as SerializableError).Count == 1);
            Assert.IsTrue(((result as BadRequestObjectResult).Value as SerializableError).ContainsKey(fieldName));
        }

        protected ProductDto CreateProduct()
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
    }
}
