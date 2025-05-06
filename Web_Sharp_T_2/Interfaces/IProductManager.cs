using Web_Sharp_T_2.DTO;

namespace Web_Sharp_T_2.Interfaces
{
    public interface IProductManager
    {
        IEnumerable<ProductDTO> GetProducts();
        int AddProduct(ProductDTO productDTO);
        bool DeleteProduct(int id);
        bool AddProductPrice(int id, int price);
    }
}
