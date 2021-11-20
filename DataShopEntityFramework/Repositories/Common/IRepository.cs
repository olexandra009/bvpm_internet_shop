using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DataShopEntityFramework.Repositories.Common
{
    interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

      
        Task SaveChangesAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<List<TEntity>> ListAsync();
        
        Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification); 
        Task<int> CountAsync(ISpecification<TEntity> specification);

    }
}
