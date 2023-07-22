using Microsoft.EntityFrameworkCore;
using PhongKham.Core.Interface.Base;
using PhongKham.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly PhongKhamDbContext _dbContext;
        public GenericRepository(PhongKhamDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public Task Update(T entity, params Expression<Func<T, object>>[] includes)
        {
            var entry = _dbContext.Entry(entity);

            // Include related entities
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entry.Reference(include).IsModified = true;
                }
            }

            // Set the state of the entity to Modified
            entry.State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}
