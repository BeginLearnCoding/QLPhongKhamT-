using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IBenhNhanRepository : IGenericRepository<BenhNhan>
    {
        Task<IEnumerable<BenhNhan>> GetBenhNhansListAsync();
        Task<BenhNhan> GetBenhNhanById(int id);
        Task<BenhNhan> AddBenhNhanAsync(BenhNhan benh);
        Task<BenhNhan> UpdateBenhNhan(BenhNhan benh);
        Task<BenhNhan> DeleteBenhNhan(BenhNhan benh);
    }
}
