using Microsoft.EntityFrameworkCore;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Core.Interface.Base;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.Repository
{
    public class LichHenRepository : GenericRepository<LichHen>, ILichHenRepository
    {

        private readonly DbSet<LichHen> _lichHen;
        public LichHenRepository(PhongKhamDbContext context) : base(context)
        {
            _lichHen = context.Set<LichHen>();
        }
        public async Task<LichHen> AddLichHenAsync(LichHen lichHen)
        {
            return await AddAsync(lichHen);
        }

        public Task<LichHen> DeleteLichHen(LichHen lichHen)
        {
            _dbContext.Set<LichHen>().Remove(lichHen);
            return Task.FromResult(lichHen);
        }

        public async Task<LichHen> GetLichHenById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<LichHen>> GetLichHensListAsync()
        {
            return await GetAllAsync();
        }

        public Task<LichHen> UpdateLichHen(LichHen lichHen)
        {
            _dbContext.Entry(lichHen).State = EntityState.Modified;
            return Task.FromResult(lichHen);
        }
    }
}
