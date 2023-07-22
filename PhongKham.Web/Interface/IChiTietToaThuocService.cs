using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IChiTietToaThuocService
    {
        Task<IEnumerable<ChiTietToaThuoc>> GetChiTietToaThuocsListAsync();
        Task<ChiTietToaThuoc> GetChiTietToaThuocById(int id);
        Task<ChiTietToaThuoc> AddChiTietToaThuocAsync(ChiTietToaThuoc chiTietToaThuoc);
        Task<ChiTietToaThuoc> UpdateChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc);
        Task<ChiTietToaThuoc> DeleteChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc);
    }
}
