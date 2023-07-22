using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IPhieuXetNghiemService
    {
        Task<IEnumerable<PhieuXetNghiem>> GetPhieuXetNghiemsListAsync();
        Task<PhieuXetNghiem> GetPhieuXetNghiemById(int id);
        Task<PhieuXetNghiem> AddPhieuXetNghiemAsync(PhieuXetNghiem phieuXetNghiem);
        Task<PhieuXetNghiem> UpdatePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem);
        Task<PhieuXetNghiem> DeletePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem);
    }
}
