using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class ToaThuocService : IToaThuocService
    {
        private readonly IToaThuocRepository _toaThuocRepository;
        public ToaThuocService(IToaThuocRepository toaThuocRepository)
        {
            _toaThuocRepository = toaThuocRepository;
        }
        public async Task<ToaThuoc> AddToaThuocAsync(ToaThuoc toaThuoc)
        {
            return await _toaThuocRepository.AddToaThuocAsync(toaThuoc);
        }

        public async Task<ToaThuoc> DeleteToaThuoc(ToaThuoc toaThuoc)
        {
            return await _toaThuocRepository.DeleteToaThuoc(toaThuoc);
        }

        public async Task<ToaThuoc> GetToaThuocById(int id)
        {
            return await _toaThuocRepository.GetToaThuocById(id);
        }

        public async Task<IEnumerable<ToaThuoc>> GetToaThuocsListAsync()
        {
            return await _toaThuocRepository.GetToaThuocsListAsync(a => a.chiTietToaThuocs);
        }

        public async Task<ToaThuoc> UpdateToaThuoc(ToaThuoc toaThuoc)
        {
            return await _toaThuocRepository.UpdateToaThuoc(toaThuoc);
        }
    }
}
