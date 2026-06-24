using E_Commerce.Domain.Common;
using E_Commerce.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> input, ISpecification<TEntity, TKey> specification)
        where TEntity : BaseEntity<TKey>
        {
            var inputQuery = input;
            if (specification.IncludesExperrsions.Any())
            {
                inputQuery = specification.IncludesExperrsions.Aggregate(inputQuery, (curr, next) => curr.Include(next));
            }
            return inputQuery; 
        }
    }
}
