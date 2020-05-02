using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SparkEquation.Trial.WebAPI.Data.Models
{
    [Table(nameof(Product))]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public bool Featured { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int ItemsInStock { get; set; }        
        public DateTime? ReceiptDate { get; set; }
        public double Rating { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public IList<CategoryProduct> CategoryProducts { get; set; }

        public void CopyDataFrom(Product newProduct)
        {
            Name=newProduct.Name;
            ExpirationDate = newProduct.ExpirationDate;
            ItemsInStock = newProduct.ItemsInStock;
            ReceiptDate = newProduct.ReceiptDate;
            Rating = newProduct.Rating;
            BrandId = newProduct.BrandId;
        }
    }
}
