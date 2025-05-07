using Microsoft.AspNetCore.Mvc;
using Web_Sharp_T_2.DTO;
using Web_Sharp_T_2.Interfaces;

namespace Web_Sharp_T_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet("GetProducts")]
        public ActionResult GetProducts()
        {
            var products = _productManager.GetProducts();
            return Ok(products);
        }
        [HttpPut("AddProduct")]
        public ActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            int idProduct = _productManager.AddProduct(productDTO);
            return Ok($"Товар {productDTO.Name} успешно добавлен");
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(int id)
        {
            var res = _productManager.DeleteProduct(id);
            if (res == false)
                return StatusCode(500);
            return Ok($"Товар {id} успешно удален.");
        }
        [HttpPut("AddProductPrice")]
        public ActionResult AddProductPrice(int id, int price)
        {
            bool result = _productManager.AddProductPrice(id, price);
            if (result == false)
                return StatusCode(500);
            return Ok($"На товар {id}, установлена цена = {price}");
        }
    }
}
