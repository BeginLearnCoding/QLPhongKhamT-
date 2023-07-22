using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IPhieuTiemPhongRepository : IGenericRepository<PhieuTiemPhong>
    {
        Task<IEnumerable<PhieuTiemPhong>> GetPhieuTiemPhongsListAsync();
        Task<PhieuTiemPhong> GetPhieuTiemPhongById(int id);
        Task<PhieuTiemPhong> AddPhieuTiemPhongAsync(PhieuTiemPhong phieuTiemPhong);
        Task<PhieuTiemPhong> UpdatePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong);
        Task<PhieuTiemPhong> DeletePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong);
    }
}
