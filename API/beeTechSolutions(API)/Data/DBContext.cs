using beeTechSolutions_API_.Models;
using Microsoft.EntityFrameworkCore;

namespace beeTechSolutions_API_.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Desktop> Desktops { get; set; }
        public DbSet<Gaming_Chair> Gaming_Chairs{ get; set; }
        public DbSet<Gaming_Console> Gaming_Console { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
