using E_commerce.Application.Common;
using E_commerce.Application.DTOs.Baskes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Contracts
{
   public interface IBasketService
    {
        // get basket  => basket dto
        public Task<Result<BasketDTO>> GetBasketAsync(string id, CancellationToken ct = default);

        //create or update  basket => basket dto
        public Task<Result<BasketDTO>> CreateOrUpdateBasketAsync(BasketDTO basketDTO, TimeSpan? TTL = default,CancellationToken ct = default);
        // delete basket => bool

        public Task<Result<bool>> DeleteBasketAsync(string id, CancellationToken ct = default);
    }
}
