using E_commerce.Application.Contracts;
using E_commerce.Application.DTOs.Baskes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
   
    public class BasketController : ApiBaseController
    {
        private readonly IBasketService basketService;

        // GET baseurl / api/basket / id

        // post baseurl / api / basket  => from body basket dto 
        // delete baseurl / api/ basket / id 


        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BasketDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<BasketDTO>> GetBasket(string id , CancellationToken ct )
        {
            var res = await basketService.GetBasketAsync(id, ct);
            return ToActionResult(res);
        }
        [HttpPost]

        public async Task<ActionResult<BasketDTO>> CreateOrUpdateBasket(BasketDTO basketDTO , CancellationToken ct )
        {
            var res = await basketService.CreateOrUpdateBasketAsync(basketDTO, ct: ct);
            return ToActionResult(res);

        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string id , CancellationToken ct )
        {
            var res =await  basketService.DeleteBasketAsync(id, ct);
            return ToActionResult (res);
        }
    }
}
