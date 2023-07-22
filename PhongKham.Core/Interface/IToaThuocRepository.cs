using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IToaThuocRepository : IGenericRepository<ToaThuoc>
    {
        Task<IEnumerable<ToaThuoc>> GetToaThuocsListAsync(params Expression<Func<ToaThuoc, object>>[] includes);
        Task<ToaThuoc> GetToaThuocById(int id);
        Task<ToaThuoc> AddToaThuocAsync(ToaThuoc toaThuoc);
        Task<ToaThuoc> UpdateToaThuoc(ToaThuoc toaThuoc);
        Task<ToaThuoc> DeleteToaThuoc(ToaThuoc toaThuoc);
    }
}
