using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using DataShopEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataShopEntityFramework.Repositories.Common
{
    public class RepositoryBase<TEntity>: IRepository<TEntity>
        where TEntity : DBModel
    {
        protected readonly DbContext _dbContext;
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var keys = new object[] { id };
            return await _dbContext.Set<TEntity>().FindAsync(keys); 
        }


        public async Task<List<TEntity>> ListAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            var specResult = ApplySpecification(specification);
            return await specResult.ToListAsync();
        }
        public virtual async Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            var specResult = ApplySpecification(specification);
            return await specResult.CountAsync();

        }
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            var evaluator = new SpecificationEvaluator<TEntity>();
            return evaluator.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
