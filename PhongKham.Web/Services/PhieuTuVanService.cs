using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class PhieuTuVanService : IPhieuTuVanService
    {
        private readonly IPhieuTuVanRepository _phieuTuVanRepository;
        public PhieuTuVanService(IPhieuTuVanRepository phieuTuVanRepository)
        {
            _phieuTuVanRepository = phieuTuVanRepository;
        }
        public async Task<PhieuTuVan> AddPhieuTuVanAsync(PhieuTuVan phieuTuVan)
        {
            return await _phieuTuVanRepository.AddPhieuTuVanAsync(phieuTuVan);
        }

        public async Task<PhieuTuVan> DeletePhieuTuVan(PhieuTuVan phieuTuVan)
        {
            return await _phieuTuVanRepository.DeletePhieuTuVan(phieuTuVan);
        }

        public async Task<PhieuTuVan> GetPhieuTuVanById(int id)
        {
            return await _phieuTuVanRepository.GetPhieuTuVanById(id);
        }

        public async Task<IEnumerable<PhieuTuVan>> GetPhieuTuVansListAsync()
        {
            return await _phieuTuVanRepository.GetPhieuTuVansListAsync();
        }

        public async Task<PhieuTuVan> UpdatePhieuTuVan(PhieuTuVan phieuTuVan)
        {
            return await _phieuTuVanRepository.UpdatePhieuTuVan(phieuTuVan);
        }
    }
}
