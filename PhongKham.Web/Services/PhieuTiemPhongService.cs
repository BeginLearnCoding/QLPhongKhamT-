using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class PhieuTiemPhongService : IPhieuTiemPhongService
    {
        private readonly IPhieuTiemPhongRepository _phieuTiemPhongRepository;
        public PhieuTiemPhongService(IPhieuTiemPhongRepository phieuTiemPhongRepository)
        {
            _phieuTiemPhongRepository = phieuTiemPhongRepository;
        }
        public async Task<PhieuTiemPhong> AddPhieuTiemPhongAsync(PhieuTiemPhong phieuTiemPhong)
        {
            return await _phieuTiemPhongRepository.AddPhieuTiemPhongAsync(phieuTiemPhong);
        }

        public async Task<PhieuTiemPhong> DeletePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong)
        {
            return await _phieuTiemPhongRepository.DeletePhieuTiemPhong(phieuTiemPhong);
        }

        public async Task<PhieuTiemPhong> GetPhieuTiemPhongById(int id)
        {
            return await _phieuTiemPhongRepository.GetPhieuTiemPhongById(id);
        }

        public async Task<IEnumerable<PhieuTiemPhong>> GetPhieuTiemPhongsListAsync()
        {
            return await _phieuTiemPhongRepository.GetPhieuTiemPhongsListAsync();
        }

        public async Task<PhieuTiemPhong> UpdatePhieuTiemPhong(PhieuTiemPhong phieuTiemPhong)
        {
            return await _phieuTiemPhongRepository.UpdatePhieuTiemPhong(phieuTiemPhong);
        }
    }
}
