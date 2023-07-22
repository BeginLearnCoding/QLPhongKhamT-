using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IPhieuTuVanRepository : IGenericRepository<PhieuTuVan>
    {
        Task<IEnumerable<PhieuTuVan>> GetPhieuTuVansListAsync();
        Task<PhieuTuVan> GetPhieuTuVanById(int id);
        Task<PhieuTuVan> AddPhieuTuVanAsync(PhieuTuVan phieuTuVan);
        Task<PhieuTuVan> UpdatePhieuTuVan(PhieuTuVan phieuTuVan);
        Task<PhieuTuVan> DeletePhieuTuVan(PhieuTuVan phieuTuVan);
    }
}
