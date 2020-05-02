using Microsoft.AspNetCore.Mvc.ModelBinding;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SparkEquation.Trial.WebAPI
{
    public class ProductDto
    {

        public int? Id { get; set; }
        public string Name { get; set; }
        [Required]
        public bool? Featured { get; set; }
        [ProductExpiration]
        public DateTime? ExpirationDate { get; set; }
        [Required]
        public int? ItemsInStock { get; set; }
        public DateTime? ReceiptDate { get; set; }
        [Required]
        public double? Rating { get; set; }
        [Required]
        public int? BrandId { get; set; }
        [ProductCategory]
        public IList<int> CategoryProducts { get; set; }

        public Product ToModel()
        {
            var product = new Product();
            product.Id = Id.Value;
            product.Name = Name;
            product.Featured = Featured.Value;
            product.ExpirationDate = ExpirationDate;
            product.ItemsInStock = ItemsInStock.Value;
            product.ReceiptDate = ReceiptDate;
            product.Rating = Rating.Value;
            product.BrandId = BrandId.Value;
            product.CategoryProducts = CategoryProducts
                .Select(x => new CategoryProduct() { CategoryId = x, ProductId = Id.Value })
                .ToList();
            return product;
        }
    }
}
