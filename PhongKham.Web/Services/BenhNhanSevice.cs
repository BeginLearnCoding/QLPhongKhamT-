using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class BenhNhanSevice : IBenhNhanService
    {
        private readonly IBenhNhanRepository _benhNhanRepository;
        public BenhNhanSevice(IBenhNhanRepository benhNhanRepository)
        {
            _benhNhanRepository = benhNhanRepository;
        }

        public async Task<BenhNhan> AddBenhNhanAsync(BenhNhan benhNhan)
        {
            return await _benhNhanRepository.AddBenhNhanAsync(benhNhan);
        }

        public async Task<BenhNhan> DeleteBenhNhan(BenhNhan benhNhan)
        {
            return await _benhNhanRepository.DeleteBenhNhan(benhNhan);
        }

        public async Task<BenhNhan> GetBenhNhanById(int id)
        {
            return await _benhNhanRepository.GetBenhNhanById(id);
        }

        public async Task<IEnumerable<BenhNhan>> GetBenhNhansListAsync()
        {
            return await _benhNhanRepository.GetBenhNhansListAsync();
        }

        public async Task<BenhNhan> UpdateBenhNhan(BenhNhan benhNhan)
        {
            return await _benhNhanRepository.UpdateBenhNhan(benhNhan);
        }
    }
}
