using E_commerce.Application.Common;
using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Specification
{
    internal class ProductCountSpec : BaseSpecification<Product , int >
    {
        public ProductCountSpec(ProductQueryParam param ) : base(p => (!param.BrandId.HasValue ||  p.BrandId == param.BrandId.Value)  
        && (!param.TypeId.HasValue || p.TypeId ==param.TypeId.Value)
        &&(String.IsNullOrWhiteSpace(param.SearchValue) ||  p.Name.ToLower().Contains(param.SearchValue))
        )
        {
            
        }
    }
}
