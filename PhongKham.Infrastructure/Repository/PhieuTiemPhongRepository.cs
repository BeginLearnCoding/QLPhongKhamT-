using Microsoft.EntityFrameworkCore;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.Repository
{
    public class PhieuTiemPhongRepository : GenericRepository<PhieuTiemPhong>, IPhieuTiemPhongRepository
    {
        private readonly DbSet<PhieuTiemPhong> _phieuTiemPhong;
        public PhieuTiemPhongRepository(PhongKhamDbContext context) : base(context)
        {
            _phieuTiemPhong = context.Set<PhieuTiemPhong>();
        }

        public async Task<PhieuTiemPhong> AddPhieuTiemPhongAsync(PhieuTiemPhong phieuTiemPhong)
        {
            return await AddAsync(phieuTiemPhong);
        }

        public Task<PhieuTiemPhong> DeletePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong)
        {
            _dbContext.Set<PhieuTiemPhong>().Remove(phieuTiemPhong);
            return Task.FromResult(phieuTiemPhong);
        }

        public async Task<PhieuTiemPhong> GetPhieuTiemPhongById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<PhieuTiemPhong>> GetPhieuTiemPhongsListAsync()
        {
            return await GetAllAsync();
        }

        public Task<PhieuTiemPhong> UpdatePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong)
        {
            _dbContext.Entry(phieuTiemPhong).State = EntityState.Modified;
            return Task.FromResult(phieuTiemPhong);
        }
    }
}
