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
    public class PhieuXetNghiemRepository : GenericRepository<PhieuXetNghiem>, IPhieuXetNghiemRepositoy
    {
        private readonly DbSet<PhieuXetNghiem> _phieuXetNghiem;
        public PhieuXetNghiemRepository(PhongKhamDbContext context) : base(context)
        {
            _phieuXetNghiem = context.Set<PhieuXetNghiem>();
        }

        public async Task<PhieuXetNghiem> AddPhieuXetNghiemAsync(PhieuXetNghiem phieuXetNghiem)
        {
            return await AddAsync(phieuXetNghiem);
        }

        public Task<PhieuXetNghiem> DeletePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem)
        {

            _dbContext.Set<PhieuXetNghiem>().Remove(phieuXetNghiem);
            return Task.FromResult(phieuXetNghiem);
        }

        public async Task<PhieuXetNghiem> GetPhieuXetNghiemById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<PhieuXetNghiem>> GetPhieuXetNghiemsListAsync()
        {
            return await GetAllAsync();
        }

        public Task<PhieuXetNghiem> UpdatePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem)
        {
            _dbContext.Entry(phieuXetNghiem).State = EntityState.Modified;
            return Task.FromResult(phieuXetNghiem);
        }
    }
}
