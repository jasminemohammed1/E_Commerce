using E_Commerce.Domain.Common;
using E_Commerce.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Specification
{
    internal abstract class BaseSpecification<TEntity,Tkey> : ISpecification< TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludesExperrsions { get; } = [];

        protected void AddInclude(Expression<Func<TEntity , object>> exp)
        {
            IncludesExperrsions.Add(exp);
        }
    }
    
}
