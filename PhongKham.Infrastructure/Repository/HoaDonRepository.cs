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
    public class HoaDonRepository : GenericRepository<HoaDon>, IHoaDonRepository
    {
        private readonly DbSet<HoaDon> _hoaDon;
        public HoaDonRepository(PhongKhamDbContext context) : base(context)
        {
            _hoaDon = context.Set<HoaDon>();
        }
        public async Task<HoaDon> AddHoaDonAsync(HoaDon hoaDon)
        {
            return await AddAsync(hoaDon);
        }

        public Task<HoaDon> DeleteHoaDon(HoaDon hoaDon)
        {
            _dbContext.Set<HoaDon>().Remove(hoaDon);
            return Task.FromResult(hoaDon);
        }

        public async Task<HoaDon> GetHoaDonById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<HoaDon>> GetHoaDonsListAsync()
        {
            return await GetAllAsync();
        }

        public Task<HoaDon> UpdateHoaDon(HoaDon hoaDon)
        {
            _dbContext.Entry(hoaDon).State = EntityState.Modified;
            return Task.FromResult(hoaDon);
        }
    }
}
