using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace beeTechSolutions_API_.Models
{
    public class Laptop 
    {
        [Key]
        public int laptop_id { get; set; }

        public string laptopBrand { get; set; } = string.Empty;
        public decimal price { get; set; } 
    }
}
