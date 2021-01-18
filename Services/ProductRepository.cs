using System.Collections.Generic;
using System.Threading.Tasks;
using wxapichallenge.Data;
using wxapichallenge.Entities;

namespace wxapichallenge.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly IServiceContext _context;

        public ProductRepository(IServiceContext context) => _context = context
            ?? throw new System.ArgumentNullException(nameof(context));

        public Task<IEnumerable<Product>> GetProducts()
        {
            return _context.GetProductsAsync();
        }

        public Task<IEnumerable<ShopperHistory>> GetShopperHistories()
        {
            return _context.GetShopperHistoryAsync();
        }
    }
}