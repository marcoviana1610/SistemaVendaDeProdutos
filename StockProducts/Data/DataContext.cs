using Microsoft.EntityFrameworkCore;
using StockProducts.Entities;

namespace StockProducts.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options ) : base(options) 
        {
        
        }

        public DbSet<Products> Products { get; set; }
    }
}
