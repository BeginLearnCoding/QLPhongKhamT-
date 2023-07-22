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
    public class PhieuTuVanRepository : GenericRepository<PhieuTuVan>,IPhieuTuVanRepository
    {
        private readonly DbSet<PhieuTuVan> _phieuTuVans;
        public PhieuTuVanRepository(PhongKhamDbContext context) : base(context)
        {
            _phieuTuVans = context.Set<PhieuTuVan>();
        }

        public async Task<PhieuTuVan> AddPhieuTuVanAsync(PhieuTuVan phieuTuVan)
        {
            return await AddAsync(phieuTuVan);
        }

        public Task<PhieuTuVan> DeletePhieuTuVan(PhieuTuVan phieuTuVan)
        {
            _dbContext.Set<PhieuTuVan>().Remove(phieuTuVan);
            return Task.FromResult(phieuTuVan);
        }

        public async Task<PhieuTuVan> GetPhieuTuVanById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<PhieuTuVan>> GetPhieuTuVansListAsync()
        {
            return await GetAllAsync();
        }

        public Task<PhieuTuVan> UpdatePhieuTuVan(PhieuTuVan phieuTuVan)
        {
            _dbContext.Entry(phieuTuVan).State = EntityState.Modified;
            return Task.FromResult(phieuTuVan);
        }
    }
}
