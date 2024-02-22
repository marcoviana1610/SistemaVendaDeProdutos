using StockProducts.Entities;

namespace StockProducts.Repository
{
    public interface InterfaceProducts
    {
        Task<object> GetProducts();

        Task<object> GetProductById(int id);

        Task<object> AddProduct(Products product);

        Task<object> UpdateProduct(Products product);

        Task<object> DeleteProduct(int id);

        Task<object> SaleProduct(int id, int quantity);
    }
}
