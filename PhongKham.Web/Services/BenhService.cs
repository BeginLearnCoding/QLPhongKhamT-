using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class BenhService : IBenhService
    {
        private readonly IBenhRepository _benhRepository;
        public BenhService(IBenhRepository benhRepository)
        {
            _benhRepository = benhRepository;
        }
        public async Task<Benh> AddBenhAsync(Benh benh)
        {
            return await _benhRepository.AddBenhAsync(benh);
        }

        public async Task<Benh> DeleteBenh(Benh benh)
        {
            return await _benhRepository.DeleteBenh(benh);
        }

        public async Task<Benh> GetBenhById(int id)
        {
            return await _benhRepository.GetBenhById(id);
        }

        public async Task<IEnumerable<Benh>> GetBenhsListAsync()
        {
            return await _benhRepository.GetBenhsListAsync();
        }

        public async Task<Benh> UpdateBenh(Benh benh)
        {
            return await _benhRepository.UpdateBenh(benh);
        }
    }
}
