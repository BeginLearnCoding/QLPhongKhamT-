using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class PhieuKhamBenhService : IPhieuKhamBenhService
    {
        private readonly IPhieuKhamBenhRepository _phieuKhamBenhRepository;
        public PhieuKhamBenhService(IPhieuKhamBenhRepository phieuKhamBenhRepository)
        {
            _phieuKhamBenhRepository = phieuKhamBenhRepository;
        }
        public async Task<PhieuKhamBenh> AddPhieuKhamBenhAsync(PhieuKhamBenh phieuKhamBenh)
        {
            return await _phieuKhamBenhRepository.AddPhieuKhamBenhAsync(phieuKhamBenh);
        }

        public async Task<PhieuKhamBenh> DeletePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh)
        {
            return await _phieuKhamBenhRepository.DeletePhieuKhamBenh(phieuKhamBenh);
        }

        public async Task<PhieuKhamBenh> GetPhieuKhamBenhById(int id)
        {
            return await _phieuKhamBenhRepository.GetPhieuKhamBenhById(id);
        }
        /*
        public async Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync()
        {
            return await _phieuKhamBenhRepository.GetPhieuKhamBenhsListAsync();
        }
        */
        public async Task<IEnumerable<PhieuKhamBenh>> GetPhieuKhamBenhsListAsync(params Expression<Func<PhieuKhamBenh, object>>[] includes)
        {
            //return await _phieuKhamBenhRepository.GetPhieuKhamBenhsListAsync(bs => bs.bacSi, lh => lh.nhanVien, bn => bn.benhNhan, b => b.Benh);
            return await _phieuKhamBenhRepository.GetPhieuKhamBenhsListAsync(includes);
        }

        public async Task<PhieuKhamBenh> UpdatePhieuKhamBenh(PhieuKhamBenh phieuKhamBenh)
        {
            return await _phieuKhamBenhRepository.UpdatePhieuKhamBenh(phieuKhamBenh);
        }
    }
}
