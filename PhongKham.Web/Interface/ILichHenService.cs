using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface ILichHenService
    {
        Task<IEnumerable<LichHen>> GetLichHensListAsync();
        Task<LichHen> GetLichHenById(int id);
        Task<LichHen> AddLichHenAsync(LichHen lichHen);
        Task<LichHen> UpdateLichHen(LichHen lichHen);
        Task<LichHen> DeleteLichHen(LichHen lichHen);
    }
}
