using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IBenhNhanService
    {
        Task<IEnumerable<BenhNhan>> GetBenhNhansListAsync();
        Task<BenhNhan> GetBenhNhanById(int id);
        Task<BenhNhan> AddBenhNhanAsync(BenhNhan benhNhan);
        Task<BenhNhan> UpdateBenhNhan(BenhNhan benhNhan);
        Task<BenhNhan> DeleteBenhNhan(BenhNhan benhNhan);
    }
}
