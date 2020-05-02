using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SparkEquation.Trial.WebAPI.Data.Models
{
    [Table(nameof(Brand))]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        [ForeignKey(nameof(Product.BrandId))]
        public IList<Product> Products { get; set; }
    }
}
