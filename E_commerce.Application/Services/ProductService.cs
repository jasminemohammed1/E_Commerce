using AutoMapper;
using E_commerce.Application.Common;
using E_commerce.Application.Contracts;
using E_commerce.Application.DTOs.Products;
using E_commerce.Application.Specification;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Result<IEnumerable<BrandDto>>> GetAllBrandAsync(CancellationToken ct = default)
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAync(ct);
           var res =  mapper.Map<IEnumerable<BrandDto>>(brands);
            return Result<IEnumerable<BrandDto>>.Ok(res);

        }

        public async Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(ProductQueryParam param, CancellationToken ct = default)
        {
            var spec = new ProductWithBrandsAndTypes(param);
            var products =  await unitOfWork.GetRepository<Product, int>().GetAllAync(spec,ct);
            var res = mapper.Map<IReadOnlyList<ProductDto>>(products);
            return Result<IReadOnlyList<ProductDto>>.Ok(res);
        }

        public async Task<Result<IEnumerable<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default)
        {
            var types = await unitOfWork.GetRepository<ProductType, int>().GetAllAync(ct);
            var res = mapper.Map<IEnumerable<TypeDto>>(types);
            return Result<IEnumerable<TypeDto>>.Ok(res);
        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var spec = new ProductWithBrandsAndTypes(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(spec , ct);
            if (product == null)
                return Result<ProductDto>.Fail(Error.NotFound("Product not found", $"Product with id {id} is not found"));
            var res = mapper.Map<ProductDto>(product);

            return Result<ProductDto>.Ok(res);
        }
    }
}
