using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace beeTechSolutions_API_.Models;

public class Product
{
    [Key]
    public int products_id { get; set; }

    public string? productName { get; set; }

    public string? productDescr { get; set; }

    public int? laptop_id { get; set; }

    public int? desktop_id { get; set; }

    public int? gamingChair_id { get; set; }

    public int? gamingConsole_id { get; set; }

    //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
