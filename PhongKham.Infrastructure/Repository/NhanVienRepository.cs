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
    public class NhanVienRepository : GenericRepository<NhanVien>, INhanVienRepository
    {
        private readonly DbSet<NhanVien> _nhanVien;
        public NhanVienRepository(PhongKhamDbContext dbcontext) : base(dbcontext)
        {
            _nhanVien = dbcontext.Set<NhanVien>();
        }

        public async Task<NhanVien> AddNhanVienAsync(NhanVien benh)
        {
            return await AddAsync(benh);
        }

        public Task<NhanVien> DeleteNhanVien(NhanVien benh)
        {
            _dbContext.Set<NhanVien>().Remove(benh);
            return Task.FromResult(benh);
        }

        public async Task<NhanVien> GetNhanVienById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<NhanVien>> GetNhanViensListAsync()
        {
            return await GetAllAsync();
        }

        public Task<NhanVien> UpdateNhanVien(NhanVien benh)
        {
            _dbContext.Entry(benh).State = EntityState.Modified;
            return Task.FromResult(benh);
        }
    }
}
