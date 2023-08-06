using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IBacSiService
    {
        Task<IEnumerable<BacSi>> GetBacSisListAsync();
        Task<BacSi> GetBacSiById(int id);
        Task<BacSi> AddBacSiAsync(BacSi benh);
        Task<BacSi> UpdateBacSi(BacSi benh);
        Task<BacSi> DeleteBacSi(BacSi benh);
    }
}
