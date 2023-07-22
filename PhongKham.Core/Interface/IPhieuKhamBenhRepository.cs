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
    public interface IPhieuKhamBenhRepository : IGenericRepository<PhieuKhamBenh>
    {
        //Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync();
        Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync(params Expression<Func<PhieuKhamBenh, object>>[] includes);
        Task<PhieuKhamBenh> GetPhieuKhamBenhById(int id);
        Task<PhieuKhamBenh> AddPhieuKhamBenhAsync(PhieuKhamBenh phieuKhamBenh);
        Task<PhieuKhamBenh> UpdatePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh);
        Task<PhieuKhamBenh> DeletePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh);
    }
}
