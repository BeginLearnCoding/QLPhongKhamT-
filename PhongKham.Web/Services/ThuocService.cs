using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class ThuocService : IThuocService
    {
        private readonly IThuocRepository _thuocRepository;
        public ThuocService(IThuocRepository thuocRepository)
        {
            _thuocRepository = thuocRepository;
        }
        public async Task<Thuoc> AddThuocAsync(Thuoc thuoc)
        {
            return await _thuocRepository.AddThuocAsync(thuoc);
        }

        public async Task<Thuoc> DeleteThuoc(Thuoc thuoc)
        {
            return await _thuocRepository.DeleteThuoc(thuoc);
        }

        public async Task<Thuoc> GetThuocById(int id)
        {
            return await _thuocRepository.GetThuocById(id);
        }

        public async Task<IEnumerable<Thuoc>> GetThuocsListAsync()
        {
            return await _thuocRepository.GetThuocsListAsync();
        }

        public async Task<Thuoc> UpdateThuoc(Thuoc thuoc)
        {
            return await _thuocRepository.UpdateThuoc(thuoc);
        }
    }
}
