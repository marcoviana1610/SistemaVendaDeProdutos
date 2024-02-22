using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockProducts.Entities;
using StockProducts.Repository;

namespace StockProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly InterfaceProducts _productsInterface;
        public ProductsController(InterfaceProducts productsInterface)
        {
            _productsInterface = productsInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _productsInterface.GetProducts());
        }

        [HttpGet]
        [Route("getbyid")]
        public async Task<ActionResult> GetProductById(int id)
        {
            return Ok(await _productsInterface.GetProductById(id));
        }

        [HttpPost]
        [Route("addproduct")]
        public async Task<ActionResult> AddProduct(Products product)
        {
            return Ok( await _productsInterface.AddProduct(product));
        }


        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateProduct(Products product)
        {
            return Ok( await _productsInterface.UpdateProduct(product));
        }

        [HttpPut]
        [Route("saleproduct")]
        public async Task<ActionResult> SaleProduct(int id, int quantity)
        {
            return Ok(await _productsInterface.SaleProduct(id, quantity));
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            return Ok(await _productsInterface.DeleteProduct(id));
        }
    }
}
