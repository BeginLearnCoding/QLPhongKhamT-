using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IThuocService
    {
        Task<IEnumerable<Thuoc>> GetThuocsListAsync();
        Task<Thuoc> GetThuocById(int id);
        Task<Thuoc> AddThuocAsync(Thuoc thuoc);
        Task<Thuoc> UpdateThuoc(Thuoc thuoc);
        Task<Thuoc> DeleteThuoc(Thuoc thuoc);
    }
}
