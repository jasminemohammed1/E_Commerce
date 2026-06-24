using E_commerce.Application.Common;
using E_commerce.Application.Services;
using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Specification
{
    internal class ProductWithBrandsAndTypes : BaseSpecification<Product, int>
    {
        //get all
        public ProductWithBrandsAndTypes(ProductQueryParam param) : base( p => (!param.BrandId.HasValue ||  p.BrandId == param.BrandId.Value)  
        && (!param.TypeId.HasValue || p.TypeId ==param.TypeId.Value)
        &&(String.IsNullOrWhiteSpace(param.SearchValue) ||  p.Name.ToLower().Contains(param.SearchValue))
        )
        {
            IncludesExperrsions.Add(x => x.ProductType);
            IncludesExperrsions.Add(x => x.ProductBrand);

            switch(param.Sort)
                {
            case ProductSearchValues.PriceDesc:
                    AddOrderbyDesc(p => p.Price);
                        break;
           case ProductSearchValues.PriceAsc:
                    AddOrderby(p => p.Price);
                    break;
                case ProductSearchValues.NameDesc:
                    AddOrderbyDesc(x => x.Name);
                    break;
                case ProductSearchValues.NameAsc:
                    AddOrderby(x => x.Name);
                    break;
                default:
                    AddOrderby(x => x.Id);
                    break;

                 }
        }
        //get by id 
        public ProductWithBrandsAndTypes(int id ) : base(p => p.Id == id)
        {

            IncludesExperrsions.Add(x => x.ProductType);
            IncludesExperrsions.Add(x => x.ProductBrand);

        }
    }
}
