using System.ComponentModel.DataAnnotations;

namespace StockProducts.Entities
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public int Stock { get; set; }

        public decimal Value { get; set; }
    }
}
