using E_Commerce.Domain.Common;
using E_Commerce.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Specification
{
    internal abstract class BaseSpecification<TEntity,Tkey> : ISpecification< TEntity,Tkey> where TEntity : BaseEntity<Tkey>
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludesExperrsions { get; } = [];

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        public Expression<Func<TEntity, object>>? SortAsc { get; private set; }

        public Expression<Func<TEntity, object>>? SortDesc {  get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; private set; } 

        protected BaseSpecification(Expression<Func<TEntity , bool>> criteria)
        {
            Criteria = criteria;
        }
        protected void ApplyPagination(int pageSize , int pageIndex)
        {
           Take = pageSize;
           Skip = (pageIndex -1) * pageSize;
            IsPaginated = true;

        }
        protected void AddOrderby(Expression<Func<TEntity , object>> orderBy)
        {
            
            SortAsc = orderBy;
        }
        protected void AddOrderbyDesc(Expression<Func<TEntity, object>> orderBy)
        {
            SortDesc = orderBy; 
        }
        protected void AddInclude(Expression<Func<TEntity , object>> exp)
        {
            IncludesExperrsions.Add(exp);
        }

        
    }
    
}
