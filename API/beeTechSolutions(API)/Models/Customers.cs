using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace beeTechSolutions_API_.Models
{
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }    
        public string? firstName { get; set; }
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string? phoneNumber { get; set; }
        public String passcode { get; set; } = String.Empty;
    }
}
