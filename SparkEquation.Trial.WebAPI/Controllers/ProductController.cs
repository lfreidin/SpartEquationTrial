using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SparkEquation.Trial.WebAPI.Services;

namespace SparkEquation.Trial.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _productsService.GetAllProductDataAsync();
            return new JsonResult(results);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _productsService.GetProductAsync(Id);
            if (result == null)
            {
                return new NotFoundResult();
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductDto product)
        {
            if (!await ValidateModel(product, false))
            {
                return new BadRequestObjectResult(ModelState);
            }
            var createdProduct = await _productsService.CreateAsync(product.ToModel());
            return new JsonResult(createdProduct);
        }

        private async Task<bool> ValidateModel(ProductDto product, bool isIdRequired)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            ValidationContext vc = new ValidationContext(product);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(product, vc, validationResults, true))
            {
                foreach (var error in validationResults)
                {
                    ModelState.AddModelError(string.Join(", ", error.MemberNames), error.ErrorMessage);
                }
                return false;
            }
            if (isIdRequired && product.Id == null)
            {
                ModelState.AddModelError(nameof(product.Id), "id required for update");
                return false;
            }
            if (!await _productsService.CheckBrand(product.BrandId.Value))
            {
                ModelState.AddModelError(nameof(product.BrandId), "Invalid brand");
                return false;
            }
            if (!_productsService.CheckCategories(product.CategoryProducts))
            {
                ModelState.AddModelError(nameof(product.CategoryProducts), "Invalid category");
                return false;
            }
            return true;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductDto product)
        {
            if (!await ValidateModel(product, true))
            {
                return new BadRequestObjectResult(ModelState);
            }
            var updatedProduct = await _productsService.UpdateAsync(product.ToModel());
            if (updatedProduct == null)
            {
                return new NotFoundResult();
            }
            return new JsonResult(updatedProduct);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await _productsService.DeleteAsync(Id))
            {
                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}