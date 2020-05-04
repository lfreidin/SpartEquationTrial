using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SparkEquation.Trial.WebAPI.Data;
using SparkEquation.Trial.WebAPI.Data.Factory;
using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IContextFactory _factory;

        public ProductsService(IContextFactory contextFactory)
        {
            _factory = contextFactory;
        }

        public async Task<List<Product>> GetAllProductDataAsync()
        {
            using (var context = _factory.GetContext())
            {
                return await context.Products.ToListAsync();
            }
        }

        public async Task<Product> GetProductAsync(int id)
        {
            using (var context = _factory.GetContext())
            {
                return await context.Products
                    .Include(x => x.CategoryProducts)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Product> CreateAsync(Product product)
        {
            using (var context = _factory.GetContext())
            {
                SetFeatured(product);
                context.Add(product);
                await context.SaveChangesAsync();
                return product;
            }
        }

        private static void SetFeatured(Product product)
        {
            if (product.Rating > 8)
            {
                product.Featured = true;
            }
        }

        public async Task<Product> UpdateAsync(Product newProduct)
        {
            using (var context = _factory.GetContext())
            {
                var existingProduct = await GetProductAsync(newProduct.Id);
                if (existingProduct == null)
                {
                    return null;
                }
                SetFeatured(newProduct);                
                existingProduct.CopyDataFrom(newProduct);
                context.Entry(existingProduct).State = EntityState.Modified;
                UpdateProductCategories(context, existingProduct, newProduct);
                await context.SaveChangesAsync();
                return existingProduct;
            }
        }

        private void UpdateProductCategories(MainDbContext context, Product oldProduct,Product newProduct)
        {
            var newCategories = newProduct.GetSortedCategories();
            var oldCategories = oldProduct.GetSortedCategories();
            if (newCategories.SequenceEqual(oldCategories))
            {
                return;
            }
            context.CategoryProducts.RemoveRange(context.CategoryProducts
                .Where(x => x.ProductId == oldProduct.Id));
            context.CategoryProducts
                .AddRange(newCategories
                .Select(x => new CategoryProduct() { ProductId = oldProduct.Id, CategoryId = x }));
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = _factory.GetContext())
            {
                var existingProduct = await GetProductAsync(id);
                if (existingProduct == null)
                {
                    return false;
                }
                context.Remove(existingProduct);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public Task<bool> CheckBrand(int brandId)
        {
            using (var context = _factory.GetContext())
            {
                return context.Brands.AnyAsync(brand => brand.Id == brandId);
            }
        }

        public bool CheckCategories(IList<int> categoryProducts)
        {
            using (var context = _factory.GetContext())
            {
                return categoryProducts.All(x => context.Categories.Any(y => y.Id == x));
            }
        }
    }
}