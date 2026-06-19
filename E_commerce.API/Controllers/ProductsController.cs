using E_commerce.Application.Common;
using E_commerce.Application.Contracts;
using E_commerce.Application.DTOs.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GetAllProducts

        [HttpGet]
        public async Task<ActionResult<Result<IReadOnlyList<ProductDto>>>>GetAllProducts(CancellationToken ct)
        {
            var res = await productService.GetAllProductsAsync(ct);
            return Ok(res);
        }
        // GetProductById

        [HttpGet("{id}")]

        public async Task<ActionResult<Result<ProductDto>>> GetProduct(int id , CancellationToken ct )
        {
            var res = await productService.GetProductByIdAsync(id, ct);
            return Ok(res);

        }
        //GetAllTypes

        [HttpGet("types")]

        public async Task<ActionResult<Result<IEnumerable<TypeDto>>>> GetAllTypes(CancellationToken ct)
        {
            var res = await productService.GetAllTypesAsync(ct);
            return Ok(res);
        }

        // GetAllBrands
        [HttpGet("brandes")]
        public async Task<ActionResult<Result<IEnumerable<TypeDto>>>> GetAllBrandes(CancellationToken ct)
        {
            var res = await productService.GetAllBrandAsync(ct);
            return Ok(res);
        }
    }
}
