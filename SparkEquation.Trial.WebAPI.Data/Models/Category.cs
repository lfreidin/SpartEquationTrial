using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SparkEquation.Trial.WebAPI.Data.Models
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CategoryProduct> CategoryProducts { get; set; }
    }
}
