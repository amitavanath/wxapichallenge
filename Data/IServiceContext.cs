using System.Collections.Generic;
using System.Threading.Tasks;
using wxapichallenge.Entities;

namespace wxapichallenge.Data
{
    public interface IServiceContext
    {
         public Task<IEnumerable<Product>> GetProductsAsync();

         public Task<IEnumerable<ShopperHistory>> GetShopperHistoryAsync();
    }
}