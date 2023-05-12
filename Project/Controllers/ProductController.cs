using Core.Dtos;
using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private ProductService productService { get; set; }

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet("/get-all")]
        [Authorize(Roles = "Administrator, User")]
        public ActionResult<List<Product>> GetAll()
        {
            var result = productService.GetAll();
            return Ok(result);
        }

        [HttpGet("/get/{productId}")]
        [Authorize(Roles = "Administrator, User")]
        public ActionResult<Product> GetById(int productId)
        {
            var result = productService.GetById(productId);

            if (result == null)
            {
                return BadRequest("Product not fount!");
            }

            return Ok(result);
        }

        [HttpPost("/add")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Add([FromBody] ProductAddDto payload)
        {
            var result = productService.AddProduct(payload);

            if (result == null)
            {
                return BadRequest("Product cannot be added");
            }

            return Ok(result);
        }

        [HttpDelete("/delete/{productId}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<Product> DeleteById(int productId)
        {
            var result = productService.DeleteById(productId);

            if (result == null)
            {
                return BadRequest("Product not found!");
            }

            return Ok(result);
        }

        [HttpPatch("/edit")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<bool> Update([FromBody] UpdateProductDto product)
        {
            var result = productService.UpdateProduct(product);

            if (!result)
            {
                return BadRequest("Product could not be updated.");
            }

            return result;
        }
    }
}
