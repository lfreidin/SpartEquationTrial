using SparkEquation.Trial.WebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SparkEquation.Trial.WebAPI.Validation
{
    public class ProductExpirationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var product = (ProductDto)validationContext.ObjectInstance;
            if (product.ExpirationDate.HasValue && (product.ExpirationDate.Value - DateTime.Now).TotalDays < 30)
            {
                return new ValidationResult("Expiration date can't be earlier than 30 days from now",
                        new List<string>(new string[] { nameof(product.ExpirationDate) }));
            }
            return ValidationResult.Success;
        }
    }
}
