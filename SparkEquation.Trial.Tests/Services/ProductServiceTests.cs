using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.Tests.Data;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SparkEquation.Trial.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        ProductsService productService = new ProductsService(new TestContextFactory());


        [TestMethod]
        public async Task CreateValid()
        {
            Product product;
            product = await CreateProduct(1000);
            var loadedProduct = await productService.GetProductAsync(product.Id);
            Assert.IsNotNull(loadedProduct);
        }

        private async Task<Product> CreateProduct(int id)
        {
            var product = new Product();
            product.Id = id;
            product.Name = "Test product";
            product.ItemsInStock = 10;
            product.Rating = 5;
            product.ReceiptDate = new System.DateTime(2020, 1, 1);
            product.BrandId = 1;
            product.Featured = false;
            product.CategoryProducts = new List<CategoryProduct>() { new CategoryProduct() { CategoryId = 1, ProductId = product.Id } };
            product.ExpirationDate = DateTime.Now.AddDays(5);
            await productService.CreateAsync(product);
            return product;
        }

        [TestMethod]
        public async Task SetFeatured()
        {
            var product = new Product();
            product.Id = 1001;
            product.Name = "Test product 2";
            product.ItemsInStock = 10;
            product.Rating = 9;
            product.ReceiptDate = new System.DateTime(2020, 1, 1);
            product.BrandId = 1;
            product.Featured = false;
            product.CategoryProducts = new List<CategoryProduct>() { new CategoryProduct() { CategoryId = 1, ProductId = product.Id } };
            product.ExpirationDate = DateTime.Now.AddDays(5);
            await productService.CreateAsync(product);
            var loadedProduct = await productService.GetProductAsync(product.Id);
            Assert.IsTrue(loadedProduct.Featured);
        }

        [TestMethod]
        public async Task UpdateName()
        {
            var productId = 1003;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.Name = "Test product updated";
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(loadedProduct.Name, updatedProduct.Name);
        }

        [TestMethod]
        public async Task UpdateRating()
        {
            var productId = 1004;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.Rating = 6;
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(loadedProduct.Rating, updatedProduct.Rating);
        }

        [TestMethod]
        public async Task UpdateStock()
        {
            var productId = 1005;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.ItemsInStock = 20;
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(loadedProduct.ItemsInStock, updatedProduct.ItemsInStock);
        }

        [TestMethod]
        public async Task UpdateBrand()
        {
            var productId = 1006;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.BrandId = 2;
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(loadedProduct.BrandId, updatedProduct.BrandId);
        }

        [TestMethod]
        public async Task UpdateRecieptDate()
        {
            var productId = 1007;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.ReceiptDate = new DateTime(2020, 4, 1);
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(loadedProduct.ReceiptDate, updatedProduct.ReceiptDate);
        }

        [TestMethod]
        public async Task UpdateExpirationDate()
        {
            var productId = 1008;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.ExpirationDate = DateTime.Now.AddDays(20);
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(loadedProduct.ReceiptDate, updatedProduct.ReceiptDate);
        }

        [TestMethod]
        public async Task UpdateCategories()
        {
            var productId = 1009;
            await CreateProduct(productId);
            var loadedProduct = (await productService.GetProductAsync(productId));
            loadedProduct.CategoryProducts.Add(new CategoryProduct() { ProductId = productId, CategoryId = 2 });
            await productService.UpdateAsync(loadedProduct);
            var updatedProduct = await productService.GetProductAsync(productId);
            Assert.AreEqual(2, updatedProduct.CategoryProducts.Count);
        }

        [TestMethod]
        public async Task DeleteProduct()
        {
            var productId = 1010;
            await CreateProduct(productId);
            var result = await productService.DeleteAsync(productId);
            Assert.IsTrue(result);
            result = await productService.DeleteAsync(productId);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public async Task GetProducts()
        {
            var result = await productService.GetAllProductDataAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count>0);
        }

        [TestMethod]
        public async Task GetProduct()
        {
            var productId = 1012;
            await CreateProduct(productId);
            var result = await productService.GetProductAsync(productId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CheckBrandTest()
        {
            var result = await productService.CheckBrand(1);
            Assert.IsTrue(result);
            result = await productService.CheckBrand(1000);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CheckCategoriesTest()
        {
            var categoryProducts = new List<int>() { 1,2 };
            var result = productService.CheckCategories(categoryProducts);
            Assert.IsTrue(result);
            categoryProducts = new List<int>() {  2,1000 };
            result = productService.CheckCategories(categoryProducts);
            Assert.IsFalse(result);
        }
    }
}
