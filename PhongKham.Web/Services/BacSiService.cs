using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class BacSiService : IBacSiService
    {
        private readonly IBacSiRepository _bacSiRepository;
        public BacSiService(IBacSiRepository bacSiRepository)
        {
            _bacSiRepository = bacSiRepository;
        }

        public async Task<BacSi> AddBacSiAsync(BacSi bacSi)
        {
            return await _bacSiRepository.AddBacSiAsync(bacSi);
        }

        public async Task<BacSi> DeleteBacSi(BacSi bacSi)
        {
            return await _bacSiRepository.DeleteBacSi(bacSi);
        }

        public async Task<BacSi> GetBacSiById(int id)
        {
            return await _bacSiRepository.GetBacSiById(id);
        }

        public async Task<IEnumerable<BacSi>> GetBacSisListAsync()
        {
            return await _bacSiRepository.GetBacSisListAsync();
        }

        public async Task<BacSi> UpdateBacSi(BacSi bacSi)
        {
            return await _bacSiRepository.UpdateBacSi(bacSi);
        }
    }
}
