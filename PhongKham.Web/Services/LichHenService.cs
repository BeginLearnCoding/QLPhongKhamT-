using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class LichHenService : ILichHenService
    {
        private readonly ILichHenRepository _lichHenRepository;
        public LichHenService(ILichHenRepository lichHenRepository)
        {
            _lichHenRepository = lichHenRepository;
        }
        public async Task<LichHen> AddLichHenAsync(LichHen lichHen)
        {
            return await _lichHenRepository.AddLichHenAsync(lichHen);
        }

        public async Task<LichHen> DeleteLichHen(LichHen lichHen)
        {
            return await _lichHenRepository.DeleteLichHen(lichHen);
        }

        public async Task<LichHen> GetLichHenById(int id)
        {
            return await _lichHenRepository.GetLichHenById(id);
        }

        public async Task<IEnumerable<LichHen>> GetLichHensListAsync()
        {
            return await _lichHenRepository.GetLichHensListAsync();
        }

        public async Task<LichHen> UpdateLichHen(LichHen lichHen)
        {
            return await _lichHenRepository.UpdateLichHen(lichHen);
        }
    }
}
