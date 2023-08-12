using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagementAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _products;
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            product.ProductId = _products.Count + 1;
            product.CreatedDate = DateTime.UtcNow;
            _products.Add(product);
            return CreatedAtAction(nameof(GetProducts), product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound("no product found with this id.");
            }

            _products.Remove(product);
            return NotFound("product deleted successfully");
        }

        [HttpGet("{id}")]
public ActionResult<Product> GetProductById(int id)
{
    var product = _products.FirstOrDefault(p => p.ProductId == id);
    if (product == null)
    {
        return NotFound("Product not found.");
    }

    return product;
}

    }
}
