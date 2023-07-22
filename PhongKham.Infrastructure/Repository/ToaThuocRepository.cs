using Microsoft.EntityFrameworkCore;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.Repository
{
    public class ToaThuocRepository : GenericRepository<ToaThuoc>, IToaThuocRepository
    {
        private readonly DbSet<ToaThuoc> _toaThuoc;
        public ToaThuocRepository(PhongKhamDbContext context): base(context)
        {
            _toaThuoc = context.Set<ToaThuoc>();
        }
        public async Task<ToaThuoc> AddToaThuocAsync(ToaThuoc toaThuoc)
        {
            return await AddAsync(toaThuoc);
        }

        public Task<ToaThuoc> DeleteToaThuoc(ToaThuoc toaThuoc)
        {
            _dbContext.Set<ToaThuoc>().Remove(toaThuoc);
            return Task.FromResult(toaThuoc);
        }

        public async Task<ToaThuoc> GetToaThuocById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<ToaThuoc>> GetToaThuocsListAsync(params Expression<Func<ToaThuoc, object>>[] includes)
        {
            return await GetAllAsync(includes);
        }

        public Task<ToaThuoc> UpdateToaThuoc(ToaThuoc toaThuoc)
        {
            _dbContext.Entry(toaThuoc).State = EntityState.Modified;
            return Task.FromResult(toaThuoc);
        }
    }
}
