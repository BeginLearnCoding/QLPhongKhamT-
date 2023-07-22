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
    public class PhieuKhamBenhRepository : GenericRepository<PhieuKhamBenh>, IPhieuKhamBenhRepository
    {
        private readonly DbSet<PhieuKhamBenh> _phieuKhamBenh;
        public PhieuKhamBenhRepository(PhongKhamDbContext context) : base(context)
        {
            _phieuKhamBenh = context.Set<PhieuKhamBenh>();
        }
        public async Task<PhieuKhamBenh> AddPhieuKhamBenhAsync(PhieuKhamBenh phieuKhamBenh)
        {
            return await AddAsync(phieuKhamBenh);
        }

        public Task<PhieuKhamBenh> DeletePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh)
        {
            _dbContext.Set<PhieuKhamBenh>().Remove(phieuKhamBenh);
            return Task.FromResult(phieuKhamBenh);
        }

        public async Task<PhieuKhamBenh> GetPhieuKhamBenhById(int id)
        {
            return await GetByIdAsync(id);
        }
        /*
        public async Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync()
        {
            return await GetAllAsync();
        }
        */
        public async Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync(params Expression<Func<PhieuKhamBenh, object>>[] includes)
        {
            return await GetAllAsync(includes);
        }

        public Task<PhieuKhamBenh> UpdatePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh)
        {
            _dbContext.Entry(phieuKhamBenh).State = EntityState.Modified;
            return Task.FromResult(phieuKhamBenh);
        }
    }
}
