using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface INhanVienService
    {
        Task<IEnumerable<NhanVien>> GetNhanViensListAsync();
        Task<NhanVien> GetNhanVienById(int id);
        Task<NhanVien> AddNhanVienAsync(NhanVien nhanVien);
        Task<NhanVien> UpdateNhanVien(NhanVien nhanVien);
        Task<NhanVien> DeleteNhanVien(NhanVien nhanVien);
    }
}
