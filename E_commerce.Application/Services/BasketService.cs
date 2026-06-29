using AutoMapper;
using E_commerce.Application.Common;
using E_commerce.Application.Contracts;
using E_commerce.Application.DTOs.Baskes;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    internal class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketService(IBasketRepository basketRepository , IMapper mapper )
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }
        public async Task<Result<BasketDTO>> CreateOrUpdateBasketAsync(BasketDTO basketDTO, TimeSpan? TTL = null, CancellationToken ct = default)
        {
            var customerBasket = mapper.Map<CustomerBasket>(basketDTO);
           var res = await  basketRepository.CreateOrUpdateBasketAsync(customerBasket, TTL, ct);
            return res == null ? Result<BasketDTO>.Fail(Error.Failure("BasketCreate.Failure", "Cannot create or update basket")) 
                : Result<BasketDTO>.Ok(mapper.Map<BasketDTO>(basketDTO));
        }

        public async  Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
           var res =  await basketRepository.DeleteBasketAsync(id, ct);
            return res ? Result<bool>.Ok(true) : Result<bool>.Fail(Error.Failure("Basket Delete Failure","Cannot Delete Basket"));
        }

        public async Task<Result<BasketDTO>> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var basket = await  basketRepository.GetBasketAsync(id, ct);
            return basket == null ? Result<BasketDTO>.Fail(Error.NotFound("Basket Not Found")) :
                Result<BasketDTO>.Ok(mapper.Map<BasketDTO>(basket));
        }
    }
}
