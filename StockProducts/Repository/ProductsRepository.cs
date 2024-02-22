using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StockProducts.Data;
using StockProducts.Entities;

namespace StockProducts.Repository
{
    public class ProductsRepository : InterfaceProducts
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<object> AddProduct(Products product)
        {
            _context.Products.Add(product);

            return await _context.SaveChangesAsync();

        }

        public async Task<object> DeleteProduct(int id)
        {
            Products product = _context.Products.FirstOrDefault(x => x.Id == id);

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<object> GetProductById(int id)
        {
            Products product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) {
                return null;
            }

            return product;
        }

        public async Task<object> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<object> SaleProduct(int id, int quantity)
        {
            Products product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                if (product.Stock >= quantity)
                {
                    decimal totalSaleValue = product.Value * quantity;

                    product.Stock -= quantity;

                    _context.Products.Update(product);

                    await _context.SaveChangesAsync();

                    return (object)totalSaleValue;
                }
                else
                {
                    return (object)"Estoque insuficiente";
                }
            }
            else
            {
                return (object)"Produto não encontrado";
            }
        }



        public async Task<object> UpdateProduct(Products product)
        {
            Products products =  _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);

            if (products == null)
            {
                products = new Products();
            }

            _context.Products.Update(product);
            return await _context.SaveChangesAsync();
        }
    }
}
