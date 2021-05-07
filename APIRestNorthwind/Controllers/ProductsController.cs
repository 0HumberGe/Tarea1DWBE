using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarea1DWBE_.Backend;
using Tarea1DWBE_.DataAccess;
using Tarea1DWBE_.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRestNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private ProductSC productService = new ProductSC();

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetAllProducts().Select(s => new Product {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                SupplierId = s.SupplierId,
                CategoryId = s.CategoryId,
                QuantityPerUnit = s.QuantityPerUnit,
                UnitPrice = s.UnitPrice,
                UnitsInStock = s.UnitsInStock,
                UnitsOnOrder = s.UnitsOnOrder,
                ReorderLevel = s.ReorderLevel,
                Discontinued = s.Discontinued

            }).ToList();

            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = productService.GetProductById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message)
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel newProduct)
        {
            try
            {
                productService.AddNewProduct(newProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return ThrowInternalErrorServer(ex);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                productService.DeleteProductById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return ThrowInternalErrorServer(ex);
            }
        }

        #region helpers

        private IActionResult ThrowInternalErrorServer(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        #endregion
    }

}
