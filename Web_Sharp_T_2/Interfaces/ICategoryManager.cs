using Web_Sharp_T_2.DTO;

namespace Web_Sharp_T_2.Interfaces
{
    public interface ICategoryManager
    {
        IEnumerable<CategoryDTO> GetCategories();
        int AddCategory(CategoryDTO categoryDTO);
        bool DeleteCategory(int id);
    }
}
