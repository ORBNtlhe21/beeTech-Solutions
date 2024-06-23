using beeTechSolutions_API_.Models;
using Microsoft.EntityFrameworkCore;

namespace beeTechSolutions_API_.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customers> Customers {  get; set; } 
    }
}
