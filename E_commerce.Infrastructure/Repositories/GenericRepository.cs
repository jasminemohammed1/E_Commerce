using E_commerce.Infrastructure.Data;
using E_commerce.Infrastructure.Specifications;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repositories
{
    internal class GenericRepository<TEntity, Tkey>(StoreDbContext db) : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
          db.Set<TEntity>().Remove(entity);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAync(CancellationToken ct = default)
        {
            return await db.Set<TEntity>().ToListAsync(ct);
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAync(ISpecification<TEntity,Tkey> spec, CancellationToken ct = default)
        {
            var res = SpecificationEvaluator.CreateQuery(db.Set<TEntity>(), spec);
            return await res.ToListAsync(ct); 
        }

        public async Task<TEntity?> GetByIdAsync(Tkey id, CancellationToken ct = default)
        {
            return await db.Set<TEntity>().FindAsync(id, ct);
        }

        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, Tkey> spec, CancellationToken ct = default)
        {
            var res = SpecificationEvaluator.CreateQuery<TEntity, Tkey>(db.Set<TEntity>(), spec);
            return await res.FirstOrDefaultAsync(ct);
        }

        public void Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }
    }
}
