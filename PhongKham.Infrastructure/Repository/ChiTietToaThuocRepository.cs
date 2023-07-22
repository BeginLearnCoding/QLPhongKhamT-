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
    public class ChiTietToaThuocRepository : GenericRepository<ChiTietToaThuoc>, IChiTietToaThuocRepository
    {
        private readonly DbSet<ChiTietToaThuoc> _chiTietToaThuoc;
        public ChiTietToaThuocRepository(PhongKhamDbContext context) : base(context)
        {
            _chiTietToaThuoc = context.Set<ChiTietToaThuoc>();
        }
        public async Task<ChiTietToaThuoc> AddChiTietToaThuocAsync(ChiTietToaThuoc chiTietToaThuoc)
        {
            return await AddAsync(chiTietToaThuoc);
        }

        public Task<ChiTietToaThuoc> DeleteChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc)
        {
            _dbContext.Set<ChiTietToaThuoc>().Remove(chiTietToaThuoc);
            return Task.FromResult(chiTietToaThuoc);
        }

        public async Task<ChiTietToaThuoc> GetChiTietToaThuocById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<ChiTietToaThuoc>> GetChiTietToaThuocsListAsync(params Expression<Func<ChiTietToaThuoc, object>>[] includes)
        {
            return await GetAllAsync(includes);
        }

        public Task<ChiTietToaThuoc> UpdateChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc)
        {
            _dbContext.Entry(chiTietToaThuoc).State = EntityState.Modified;
            return Task.FromResult(chiTietToaThuoc);
        }
    }
}
