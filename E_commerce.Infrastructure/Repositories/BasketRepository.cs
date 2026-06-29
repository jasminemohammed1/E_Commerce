using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Baskets;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repositories
{
    internal class BasketRepository : IBasketRepository
    {
        private readonly IDatabase database;
        public BasketRepository(IConnectionMultiplexer connectionMuliplexer)
        {
            database = connectionMuliplexer.GetDatabase();
        }
        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null, CancellationToken ct = default)
        {
            var value = JsonSerializer.Serialize(basket);
            var res = await database.StringSetAsync(basket.Id, value, TimeToLive ?? TimeSpan.FromDays(7));

            return res ? basket : null;

        }

        public async Task<bool> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
            var res = await  database.KeyDeleteAsync(id);
            return res ? true : false;
        }

        public async  Task<CustomerBasket?> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var res = await database.StringGetAsync(id);
            if (res.IsNullOrEmpty) return null;
            else
            {
                return JsonSerializer.Deserialize<CustomerBasket>(res!);
            }
        }
    }
}
