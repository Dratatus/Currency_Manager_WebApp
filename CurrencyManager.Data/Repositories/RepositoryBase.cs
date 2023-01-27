using CurrencyManager.Data.Configutation;
using CurrencyManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyManager.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly CurrencyManagerDbContext _currencyManagerDbContext;

        public RepositoryBase(CurrencyManagerDbContext currencyManagerDbContext)
        {
            _currencyManagerDbContext = currencyManagerDbContext;
        }

        public async virtual Task<bool> ExistsAsync(long id)
        {
            var entity = await FindAsync(e => e.Id == id);

            bool entityExists = entity != null;
            return entityExists;
        }

        public async virtual Task<TEntity> GetAsync(long id)
        {
            var entity = await _currencyManagerDbContext.FindAsync<TEntity>(id);

            return entity;
        } 
        
        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _currencyManagerDbContext
                .Set<TEntity>()
                .ToListAsync();

            return entities;
        }

        public async virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _currencyManagerDbContext
                .Set<TEntity>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();

            return entities;
        }

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntityEntry = await _currencyManagerDbContext.AddAsync(entity);

            var addedEntity = addedEntityEntry.Entity;

            await _currencyManagerDbContext.SaveChangesAsync();

            return addedEntity;
        }

        public async virtual Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _currencyManagerDbContext.AddRangeAsync(entities);

            await _currencyManagerDbContext.SaveChangesAsync();
        }

        public async virtual Task RemoveAsync(TEntity entity)
        {
            _currencyManagerDbContext.Remove(entity);

            await _currencyManagerDbContext.SaveChangesAsync();
        }

        public async virtual Task SaveChangesAsync()
        {
            await _currencyManagerDbContext.SaveChangesAsync();
        }
    }
}
