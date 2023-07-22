using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task Update(T entity);
        Task Update(T entity, params Expression<Func<T, object>>[] includes);
        Task Delete(T entity);
    }
}
