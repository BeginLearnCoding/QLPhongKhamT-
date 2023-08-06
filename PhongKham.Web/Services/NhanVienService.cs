using PhongKham.Core.Entities;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class NhanVienService : INhanVienService
    {

        private readonly NhanVienService _nhanVienService;
        public NhanVienService(NhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }

        public async Task<NhanVien> AddNhanVienAsync(NhanVien nhanVien)
        {
            return await _nhanVienService.AddNhanVienAsync(nhanVien);
        }

        public async Task<NhanVien> DeleteNhanVien(NhanVien nhanVien)
        {
            return await _nhanVienService.DeleteNhanVien(nhanVien);
        }

        public async Task<NhanVien> GetNhanVienById(int id)
        {
            return await _nhanVienService.GetNhanVienById(id);
        }

        public async Task<IEnumerable<NhanVien>> GetNhanViensListAsync()
        {
            return await _nhanVienService.GetNhanViensListAsync();
        }

        public async Task<NhanVien> UpdateNhanVien(NhanVien nhanVien)
        {
            return await _nhanVienService.UpdateNhanVien(nhanVien);
        }
    }
}
