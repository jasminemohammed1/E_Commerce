using E_Commerce.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Specification
{
    internal class ProductWithBrandsAndTypes : BaseSpecification<Product, int>
    {
        public ProductWithBrandsAndTypes(int? BrandId , int ?TypeId) : base( p => (!BrandId.HasValue ||  p.BrandId == BrandId.Value)  && (!TypeId.HasValue || p.TypeId ==TypeId.Value))
        {
            IncludesExperrsions.Add(x => x.ProductType);
            IncludesExperrsions.Add(x => x.ProductBrand);
        }

        public ProductWithBrandsAndTypes(int id ) : base(p => p.Id == id)
        {

            IncludesExperrsions.Add(x => x.ProductType);
            IncludesExperrsions.Add(x => x.ProductBrand);

        }
    }
}
