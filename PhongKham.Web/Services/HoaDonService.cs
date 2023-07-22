using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class HoaDonService : IHoaDonService
    {
        private readonly IHoaDonRepository _hoaDonRepository;
        public HoaDonService(IHoaDonRepository hoaDonRepository)
        {
            _hoaDonRepository = hoaDonRepository;
        }
        public async Task<HoaDon> AddHoaDonAsync(HoaDon hoaDon)
        {
            return await _hoaDonRepository.AddHoaDonAsync(hoaDon);
        }

        public Task<HoaDon> DeleteHoaDon(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }

        public async Task<HoaDon> GetHoaDonById(int id)
        {
            return await _hoaDonRepository.GetHoaDonById(id);
        }

        public async Task<IEnumerable<HoaDon>> GetHoaDonsListAsync()
        {
            return await _hoaDonRepository.GetHoaDonsListAsync();
        }

        public Task<HoaDon> UpdateHoaDon(HoaDon hoaDon)
        {
            throw new NotImplementedException();
        }
    }
}
