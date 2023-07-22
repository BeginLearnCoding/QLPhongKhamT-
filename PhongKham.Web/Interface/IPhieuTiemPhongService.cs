using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IPhieuTiemPhongService
    {
        Task<IEnumerable<PhieuTiemPhong>> GetPhieuTiemPhongsListAsync();
        Task<PhieuTiemPhong> GetPhieuTiemPhongById(int id);
        Task<PhieuTiemPhong> AddPhieuTiemPhongAsync(PhieuTiemPhong phieuTiemPhong);
        Task<PhieuTiemPhong> UpdatePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong);
        Task<PhieuTiemPhong> DeletePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong);
    }
}
