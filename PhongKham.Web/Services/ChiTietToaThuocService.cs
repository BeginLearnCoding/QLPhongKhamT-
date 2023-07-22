using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class ChiTietToaThuocService : IChiTietToaThuocService
    {
        private readonly IChiTietToaThuocRepository _chiTietToaThuocRepository;
        public ChiTietToaThuocService(IChiTietToaThuocRepository chiTietToaThuocRepository)
        {
            _chiTietToaThuocRepository = chiTietToaThuocRepository;
        }
        public async Task<ChiTietToaThuoc> AddChiTietToaThuocAsync(ChiTietToaThuoc chiTietToaThuoc)
        {
            return await _chiTietToaThuocRepository.AddChiTietToaThuocAsync(chiTietToaThuoc);
        }

        public async Task<ChiTietToaThuoc> DeleteChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc)
        {
            return await _chiTietToaThuocRepository.DeleteChiTietToaThuoc(chiTietToaThuoc);
        }

        public async Task<ChiTietToaThuoc> GetChiTietToaThuocById(int id)
        {
            return await _chiTietToaThuocRepository.GetChiTietToaThuocById(id);
        }

        public async Task<IEnumerable<ChiTietToaThuoc>> GetChiTietToaThuocsListAsync()
        {
            return await _chiTietToaThuocRepository.GetChiTietToaThuocsListAsync();
        }

        public async Task<ChiTietToaThuoc> UpdateChiTietToaThuoc(ChiTietToaThuoc chiTietToaThuoc)
        {
            return await _chiTietToaThuocRepository.UpdateChiTietToaThuoc(chiTietToaThuoc);
        }
    }
}
