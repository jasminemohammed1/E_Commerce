using E_commerce.Infrastructure.Data;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repositories
{
    internal class UnitOfWork(StoreDbContext storeDbContext) : IUnitOfWork
    {

        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var key = typeof(TEntity).Name; 
            if(_repositories.TryGetValue(key, out object? value))
            {
                return (IGenericRepository<TEntity, Tkey>)value;
            }
            var repo = new GenericRepository<TEntity, Tkey>(storeDbContext);
            _repositories[key] = repo;  
            return repo;    
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await storeDbContext.SaveChangesAsync(ct);
           
        }
    }
}
