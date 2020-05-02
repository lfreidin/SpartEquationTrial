using SparkEquation.Trial.WebAPI.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SparkEquation.Trial.WebAPI.Validation
{
    public class ProductCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var product = (ProductDto)validationContext.ObjectInstance;
            if (!product.CategoryProducts.Any())
            {
                return new ValidationResult("At least 1 category should be set",
                    new List<string>(new string[] { nameof(product.CategoryProducts) }));
            }
            else
            {
                if (product.CategoryProducts.Count > 5)
                {
                    return new ValidationResult("Product can't have more than 5 categories",
                        new List<string>(new string[] { nameof(product.CategoryProducts) }));
                }
            }

            return ValidationResult.Success;
        }
    }
}
