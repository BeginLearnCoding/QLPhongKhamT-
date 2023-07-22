using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IHoaDonRepository : IGenericRepository<HoaDon>
    {
        Task<IEnumerable<HoaDon>> GetHoaDonsListAsync();
        Task<HoaDon> GetHoaDonById(int id);
        Task<HoaDon> AddHoaDonAsync(HoaDon hoaDon);
        Task<HoaDon> UpdateHoaDon(HoaDon hoaDon);
        Task<HoaDon> DeleteHoaDon(HoaDon hoaDon);
    }
}
