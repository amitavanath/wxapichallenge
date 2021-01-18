using System.Collections.Generic;
using System.Threading.Tasks;
using wxapichallenge.Entities;

namespace wxapichallenge.Services
{
    public interface IProductRepository
    {
         public Task<IEnumerable<Product>> GetProducts();

         public Task<IEnumerable<ShopperHistory>> GetShopperHistories();
    }
}