
using System.ComponentModel.DataAnnotations;

namespace beeTechSolutions_API_.Models;

public class Order
{
    [Key]
    public int order_id { get; set; }

    public decimal? total { get; set; }

    public int? customer_id { get; set; }

    public int? products_id { get; set; }

    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
