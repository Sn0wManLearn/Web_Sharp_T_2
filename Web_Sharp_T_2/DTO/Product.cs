using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Web_Sharp_T_2.DTO
{
    [Table("Product")]
    public class Product : BaseModel
    {
        [Column("Price")]
        public int Price { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public override string ToString()
        {
            return $"Id;{Id}, Name:{Name}, Description:{Description}, Price:{Price}, CategoryId:{CategoryId}";
        }
    }
}
