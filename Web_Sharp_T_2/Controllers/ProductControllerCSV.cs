using Microsoft.AspNetCore.Mvc;
using Web_Sharp_T_2.Interfaces;

namespace Web_Sharp_T_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductControllerCSV : ControllerBase
    {
        private readonly IProductControllerCSV _productControllerCSV;
        public ProductControllerCSV(IProductControllerCSV productControllerCSV)
        {
            _productControllerCSV = productControllerCSV;
        }
        [HttpGet("GetProductsSCV")]
        public FileContentResult GetProductsSCV()
        {
            var stringFile = _productControllerCSV.GetProductsCSV();
            return File(new System.Text.UTF8Encoding().GetBytes(stringFile), "text/scv", "Products.scv");
        }
    }
}
