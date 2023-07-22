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
    public interface IChiTietToaThuocRepository : IGenericRepository<ChiTietToaThuoc>
    {
         Task<IEnumerable<ChiTietToaThuoc>> GetChiTietToaThuocsListAsync(params Expression<Func<ChiTietToaThuoc, object>>[] includes);
        Task<ChiTietToaThuoc> GetChiTietToaThuocById(int id);
        Task<ChiTietToaThuoc> AddChiTietToaThuocAsync(ChiTietToaThuoc chiTietToaThuoc);
        Task<ChiTietToaThuoc> UpdateChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc);
        Task<ChiTietToaThuoc> DeleteChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc);
    }
}
