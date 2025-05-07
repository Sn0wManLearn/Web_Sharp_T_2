using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using Web_Sharp_T_2.DTO;
using Web_Sharp_T_2.Interfaces;
using Web_Sharp_T_2.DB;

namespace Web_Sharp_T_2.Repositories
{
    public class ProductControllerCSV : IProductControllerCSV
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        public ProductControllerCSV(IMapper mapper, IMemoryCache memoryCache, IConfiguration configuration)
        {
            _mapper = mapper;
            _cache = memoryCache;
            _configuration = configuration;
        }
        public string GetProductsCSV()
        {
            if (_cache.TryGetValue("products", out List<ProductDTO> productsCache))
                return GetSCV(productsCache);

            List<Product> products = new List<Product>();
            using (var db = new ContextDB(_configuration.GetValue<string>("PathToDB")))
            {
                var cat = db.Categories.ToList();
                products = db.Products.ToList();
            }
            var res = products.Select(x => _mapper.Map<ProductDTO>(x)).ToList();

            _cache.Set("products", res, TimeSpan.FromMinutes(30));

            return GetSCV(res);
        }
        private string GetSCV(List<ProductDTO> data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in data)
            {
                sb.Append($"{product.Id},{product.Name},{product.Price},{product.CategoryId},{product.Description}\n");
            }
            return sb.ToString();
        }
    }
}
