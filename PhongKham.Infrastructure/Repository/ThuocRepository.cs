using Microsoft.EntityFrameworkCore;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.Repository
{
    public class ThuocRepository : GenericRepository<Thuoc>, IThuocRepository
    {
        private readonly DbSet<Thuoc> _thuoc;
        public ThuocRepository(PhongKhamDbContext context) : base(context)
        {
            _thuoc = context.Set<Thuoc>();
        }

        public async Task<Thuoc> AddThuocAsync(Thuoc thuoc)
        {
            return await AddAsync(thuoc);
        }

        public Task<Thuoc> DeleteThuoc(Thuoc thuoc)
        {
            _dbContext.Set<Thuoc>().Remove(thuoc);
            return Task.FromResult(thuoc);
        }

        public async Task<Thuoc> GetThuocById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Thuoc>> GetThuocsListAsync()
        {
            return await GetAllAsync();
        }

        public Task<Thuoc> UpdateThuoc(Thuoc thuoc)
        {
            _dbContext.Entry(thuoc).State = EntityState.Modified;
            return Task.FromResult(thuoc);
        }
    }
}
