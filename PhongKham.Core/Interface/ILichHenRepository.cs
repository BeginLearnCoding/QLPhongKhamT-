using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface ILichHenRepository : IGenericRepository<LichHen>
    {
        Task<IEnumerable<LichHen>> GetLichHensListAsync();
        Task<LichHen> GetLichHenById(int id);
        Task<LichHen> AddLichHenAsync(LichHen lichHen);
        Task<LichHen> UpdateLichHen(LichHen lichHen);
        Task<LichHen> DeleteLichHen(LichHen lichHen);
    }
}
