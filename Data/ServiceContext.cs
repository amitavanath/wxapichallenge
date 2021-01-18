using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using wxapichallenge.Entities;

namespace wxapichallenge.Data
{
    public class ServiceContext : IServiceContext
    {
        private readonly IConfiguration _config;

        public ServiceContext(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        { 
            using (var httpClient = new HttpClient())
            {
                List<Product> productList = new List<Product>();
                using (var response = await httpClient.GetAsync(GetExternalEndPointWithTokenForProduct))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }

                return productList;
            }
        }

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistoryAsync()
        { 
            using (var httpClient = new HttpClient())
            {
                List<ShopperHistory> shopperHistoryList = new List<ShopperHistory>();
                using (var response = await httpClient.GetAsync(GetExternalEndPointWithTokenForShopperHistory))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    shopperHistoryList = JsonConvert.DeserializeObject<List<ShopperHistory>>(apiResponse);
                }

                return shopperHistoryList;
            }
        }

        public string GetExternalEndPointWithTokenForProduct
        {
            get
            {
                return _config.GetValue<string>("ExternalServiceURI") + "/products?token=" + 
                                                        _config.GetValue<string>("UserToken");
            }
        }

        public string GetExternalEndPointWithTokenForShopperHistory
        {
            get
            {
                return _config.GetValue<string>("ExternalServiceURI") + "/shopperHistory?token=" + 
                                                        _config.GetValue<string>("UserToken");
            }
        }


    }
}