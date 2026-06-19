using AutoMapper;
using E_commerce.Application.DTOs.Products;
using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Profiles
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductType, TypeDto>();
            CreateMap<Product, ProductDto>()
                .ForMember(desc => desc.ProductBrand, opts => opts.MapFrom(src => src.ProductBrand.Name))
                .ForMember(desc => desc.ProductType, opts => opts.MapFrom(src => src.ProductType.Name))
               .ForMember(des => des.PictureUrl, opts => opts.MapFrom<PictureUrlResolver>());

        }
    }
}
