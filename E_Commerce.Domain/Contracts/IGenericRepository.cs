using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Contracts
{
    public interface IGenericRepository<TEntity , Tkey> where TEntity : BaseEntity<Tkey>
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public Task<TEntity?> GetByIdAsync(Tkey id, CancellationToken ct = default);
        public Task<IReadOnlyList<TEntity>> GetAllAync(CancellationToken ct = default);

    }
}
