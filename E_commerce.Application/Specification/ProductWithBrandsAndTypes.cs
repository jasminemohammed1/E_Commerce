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
        public ProductWithBrandsAndTypes()
        {
            IncludesExperrsions.Add(x => x.ProductType);
            IncludesExperrsions.Add(x => x.ProductBrand);
        }
    }
}
