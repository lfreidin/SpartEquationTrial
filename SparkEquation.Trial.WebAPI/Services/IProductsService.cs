using System.Collections.Generic;
using System.Threading.Tasks;
using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetAllProductDataAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
        Task<bool> CheckBrand(int brandId);
        bool CheckCategories(IList<int> categoryProducts);
    }
}