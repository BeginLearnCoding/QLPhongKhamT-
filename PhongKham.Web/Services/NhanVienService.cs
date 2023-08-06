using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class NhanVienService : INhanVienService
    {

        private readonly INhanVienRepository _nhanVienRepository;
        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<NhanVien> AddNhanVienAsync(NhanVien nhanVien)
        {
            return await _nhanVienRepository.AddNhanVienAsync(nhanVien);
        }

        public async Task<NhanVien> DeleteNhanVien(NhanVien nhanVien)
        {
            return await _nhanVienRepository.DeleteNhanVien(nhanVien);
        }

        public async Task<NhanVien> GetNhanVienById(int id)
        {
            return await _nhanVienRepository.GetNhanVienById(id);
        }

        public async Task<IEnumerable<NhanVien>> GetNhanViensListAsync()
        {
            return await _nhanVienRepository.GetNhanViensListAsync();
        }

        public async Task<NhanVien> UpdateNhanVien(NhanVien nhanVien)
        {
            return await _nhanVienRepository.UpdateNhanVien(nhanVien);
        }
    }
}
