using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IHoaDonService
    {

        Task<IEnumerable<HoaDon>> GetHoaDonsListAsync();
        Task<HoaDon> GetHoaDonById(int id);
        Task<HoaDon> AddHoaDonAsync(HoaDon hoaDon);
        Task<HoaDon> UpdateHoaDon(HoaDon hoaDon);
        Task<HoaDon> DeleteHoaDon(HoaDon hoaDon);
    }
}
