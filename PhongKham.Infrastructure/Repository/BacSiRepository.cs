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
    public class BacSiRepository : GenericRepository<BacSi>, IBacSiRepository
    {
        private readonly DbSet<BacSi> _bacSi;
        public BacSiRepository(PhongKhamDbContext dbcontext) : base(dbcontext)
        {
            _bacSi = dbcontext.Set<BacSi>();
        }

        public async Task<BacSi> AddBacSiAsync(BacSi benh)
        {
            return await AddAsync(benh);
        }

        public Task<BacSi> DeleteBacSi(BacSi benh)
        {
            _dbContext.Set<BacSi>().Remove(benh);
            return Task.FromResult(benh);
        }

        public async Task<BacSi> GetBacSiById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<BacSi>> GetBacSisListAsync()
        {
            return await GetAllAsync();
        }

        public Task<BacSi> UpdateBacSi(BacSi benh)
        {
            _dbContext.Entry(benh).State = EntityState.Modified;
            return Task.FromResult(benh);
        }
    }
}
