using E_Commerce.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket ?> GetBasketAsync(string id , CancellationToken ct = default);
        public Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket customerBasket ,TimeSpan ?TimeToLive = default ,CancellationToken ct = default);
        public Task<bool> DeleteBasketAsync(string id , CancellationToken ct = default);
    }
}
