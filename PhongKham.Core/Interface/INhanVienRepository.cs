using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface INhanVienRepository : IGenericRepository<NhanVien>
    {
        Task<IEnumerable<NhanVien>> GetNhanViensListAsync();
        Task<NhanVien> GetNhanVienById(int id);
        Task<NhanVien> AddNhanVienAsync(NhanVien benh);
        Task<NhanVien> UpdateNhanVien(NhanVien benh);
        Task<NhanVien> DeleteNhanVien(NhanVien benh);
    }
}
