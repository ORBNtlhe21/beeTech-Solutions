using System.ComponentModel.DataAnnotations;

namespace beeTechSolutions_API_.Models
{
    public class Gaming_Chair
    {
        [Key]
        public int gamingChair_id{ get; set; }
        public string gamingChairBrand {  get; set; } = string.Empty;
        public decimal price { get; set; }
    }
}
