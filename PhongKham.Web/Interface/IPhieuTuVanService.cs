using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IPhieuTuVanService
    {

        Task<IEnumerable<PhieuTuVan>> GetPhieuTuVansListAsync();
        Task<PhieuTuVan> GetPhieuTuVanById(int id);
        Task<PhieuTuVan> AddPhieuTuVanAsync(PhieuTuVan phieuTuVan);
        Task<PhieuTuVan> UpdatePhieuTuVan(PhieuTuVan phieuTuVan);
        Task<PhieuTuVan> DeletePhieuTuVan(PhieuTuVan phieuTuVan);
    }
}
