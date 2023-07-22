using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IPhieuKhamBenhService
    {
        //Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync();
        Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync(params Expression<Func<PhieuKhamBenh, object>>[] includes);
        Task<PhieuKhamBenh> GetPhieuKhamBenhById(int id);
        Task<PhieuKhamBenh> AddPhieuKhamBenhAsync(PhieuKhamBenh phieuKhamBenh);
        Task<PhieuKhamBenh> UpdatePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh);
        Task<PhieuKhamBenh> DeletePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh);
    }
}
