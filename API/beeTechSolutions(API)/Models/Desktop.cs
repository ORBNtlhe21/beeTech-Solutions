using System.ComponentModel.DataAnnotations;

namespace beeTechSolutions_API_.Models
{
    public class Desktop
    {
        [Key]
        public int desktop_id { get; set; }
        public string desktopBrand { get; set; } = string.Empty;
        public decimal price { get; set; }
    }
}
