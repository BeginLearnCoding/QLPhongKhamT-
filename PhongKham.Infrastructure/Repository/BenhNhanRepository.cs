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
    public class BenhNhanRepository : GenericRepository<BenhNhan>, IBenhNhanRepository
    {
        private readonly DbSet<BenhNhan> _benhNhan;
        public BenhNhanRepository(PhongKhamDbContext dbcontext) : base(dbcontext)
        {
            _benhNhan = dbcontext.Set<BenhNhan>();
        }

        public async Task<BenhNhan> AddBenhNhanAsync(BenhNhan benh)
        {
            return await AddAsync(benh);
        }

        public Task<BenhNhan> DeleteBenhNhan(BenhNhan benh)
        {
            _dbContext.Set<BenhNhan>().Remove(benh);
            return Task.FromResult(benh);
        }

        public async Task<BenhNhan> GetBenhNhanById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<BenhNhan>> GetBenhNhansListAsync()
        {
            return await GetAllAsync();
        }

        public Task<BenhNhan> UpdateBenhNhan(BenhNhan benh)
        {
            _dbContext.Entry(benh).State = EntityState.Modified;
            return Task.FromResult(benh);
        }
    }
}
