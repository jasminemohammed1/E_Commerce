using E_commerce.Application.Common;
using E_commerce.Application.Contracts;
using E_commerce.Application.DTOs.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
  
    public class ProductsController : ApiBaseController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GetAllProducts

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>>GetAllProducts(CancellationToken ct)
        {
            var res = await productService.GetAllProductsAsync(ct);
            return ToActionResult(res);
        }
        // GetProductById
        [ProducesResponseType(typeof(ProductDto) , StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails) , StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]

        public async Task<ActionResult<ProductDto>> GetProduct(int id , CancellationToken ct )
        {
            var res = await productService.GetProductByIdAsync(id, ct);
            return ToActionResult(res);

        }
        //GetAllTypes

        [HttpGet("types")]

        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes(CancellationToken ct)
        {
            var res = await productService.GetAllTypesAsync(ct);
            return ToActionResult<IEnumerable<TypeDto>>(res);
        }

        // GetAllBrands
        [HttpGet("brandes")]
        public async Task<ActionResult<IEnumerable<BrandDto>>>GetAllBrandes(CancellationToken ct)
        {
            var res = await productService.GetAllBrandAsync(ct);
            return ToActionResult(res);
        }
    }
}
