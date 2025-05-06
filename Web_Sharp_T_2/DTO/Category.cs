using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Sharp_T_2.DTO
{
    [Table("Category")]
    public class Category : BaseModel
    {
        public virtual ICollection<Product> Products { get; set; }
        public override string ToString()
        {
            return $"Id;{Id}, Name:{Name}, Description:{Description}";
        }
    }
}
