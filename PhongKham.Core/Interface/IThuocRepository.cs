using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IThuocRepository : IGenericRepository<Thuoc>
    {
        Task<IEnumerable<Thuoc>> GetThuocsListAsync();
        Task<Thuoc> GetThuocById(int id);
        Task<Thuoc> AddThuocAsync(Thuoc thuoc);
        Task<Thuoc> UpdateThuoc(Thuoc thuoc);
        Task<Thuoc> DeleteThuoc(Thuoc thuoc);
    }
}
