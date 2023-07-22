using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IToaThuocService
    {
        Task<IEnumerable<ToaThuoc>> GetToaThuocsListAsync();
        Task<ToaThuoc> GetToaThuocById(int id);
        Task<ToaThuoc> AddToaThuocAsync(ToaThuoc toaThuoc);
        Task<ToaThuoc> UpdateToaThuoc(ToaThuoc toaThuoc);
        Task<ToaThuoc> DeleteToaThuoc(ToaThuoc toaThuoc);
    }
}
