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
    public class BenhRepository : GenericRepository<Benh>, IBenhRepository
    {
        private readonly DbSet<Benh> _benh;
        public BenhRepository(PhongKhamDbContext context) : base(context)
        {
            _benh = context.Set<Benh>();
        }
        public async Task<Benh> AddBenhAsync(Benh benh)
        {
            return await AddAsync(benh);
        }

        public Task<Benh> DeleteBenh(Benh benh)
        {
            _dbContext.Set<Benh>().Remove(benh);
            return Task.FromResult(benh);
        }

        public async Task<Benh> GetBenhById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Benh>> GetBenhsListAsync()
        {
            return await GetAllAsync();
        }

        public Task<Benh> UpdateBenh(Benh benh)
        {
            _dbContext.Entry(benh).State = EntityState.Modified;
            return Task.FromResult(benh);
        }
    }
}
