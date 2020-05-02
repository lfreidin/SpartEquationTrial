using System.ComponentModel.DataAnnotations;

namespace SparkEquation.Trial.WebAPI.Data.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}