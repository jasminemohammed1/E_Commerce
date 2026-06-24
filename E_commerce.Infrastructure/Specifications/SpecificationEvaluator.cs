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
            if(specification.Criteria is not null)
            {
               inputQuery =  inputQuery.Where(specification.Criteria);
            }
            if (specification.IncludesExperrsions.Any())
            {
                inputQuery = specification.IncludesExperrsions.Aggregate(inputQuery, (curr, next) => curr.Include(next));
            }
            if(specification.SortAsc is not null)
            {
                inputQuery = inputQuery.OrderBy(specification.SortAsc);
            }
            else if(specification.SortDesc is not null)
            {
                inputQuery = inputQuery.OrderByDescending(specification.SortDesc);  
            }

            if(specification.IsPaginated)
            {
                inputQuery = inputQuery.Skip(specification.Skip).Take(specification.Take);  
            }
                return inputQuery; 
        }
    }
}
