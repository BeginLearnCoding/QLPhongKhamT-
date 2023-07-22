using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IPhieuXetNghiemRepositoy : IGenericRepository<PhieuXetNghiem>
    {
        Task<IEnumerable<PhieuXetNghiem>> GetPhieuXetNghiemsListAsync();
        Task<PhieuXetNghiem> GetPhieuXetNghiemById(int id);
        Task<PhieuXetNghiem> AddPhieuXetNghiemAsync(PhieuXetNghiem phieuXetNghiem);
        Task<PhieuXetNghiem> UpdatePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem);
        Task<PhieuXetNghiem> DeletePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem);
    }
}
