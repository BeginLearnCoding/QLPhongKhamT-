using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class PhieuXetNghiemService : IPhieuXetNghiemService
    {
        private readonly IPhieuXetNghiemRepositoy _phieuXetNghiemRepository;
        public PhieuXetNghiemService(IPhieuXetNghiemRepositoy phieuXetNghiemRepositoy)
        {
            _phieuXetNghiemRepository = phieuXetNghiemRepositoy;
        }
        public async Task<PhieuXetNghiem> AddPhieuXetNghiemAsync(PhieuXetNghiem phieuXetNghiem)
        {
            return await _phieuXetNghiemRepository.AddPhieuXetNghiemAsync(phieuXetNghiem);
        }

        public async Task<PhieuXetNghiem> DeletePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem)
        {
            return await _phieuXetNghiemRepository.DeletePhieuXetNghiem(phieuXetNghiem);
        }

        public async Task<PhieuXetNghiem> GetPhieuXetNghiemById(int id)
        {
            return await _phieuXetNghiemRepository.GetPhieuXetNghiemById(id);
        }

        public async Task<IEnumerable<PhieuXetNghiem>> GetPhieuXetNghiemsListAsync()
        {
            return await _phieuXetNghiemRepository.GetPhieuXetNghiemsListAsync()
;        }

        public async Task<PhieuXetNghiem> UpdatePhieuXetNghiem(PhieuXetNghiem phieuXetNghiem)
        {
            return await _phieuXetNghiemRepository.UpdatePhieuXetNghiem(phieuXetNghiem);
        }
    }
}
