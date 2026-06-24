using E_commerce.Application.Common;
using E_commerce.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Contracts
{
    public interface IProductService
    {
        public Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(ProductQueryParam param,CancellationToken ct = default);
        public Task<Result<ProductDto>> GetProductByIdAsync(int id , CancellationToken ct = default);
        public Task<Result<IEnumerable<BrandDto>>> GetAllBrandAsync(CancellationToken ct = default);
        public Task<Result<IEnumerable<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default);
    }
}
