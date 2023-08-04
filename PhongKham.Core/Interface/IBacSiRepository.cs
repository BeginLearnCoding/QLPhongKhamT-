using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IBacSiRepository : IGenericRepository<BacSi>
    {
        Task<IEnumerable<BacSi>> GetBacSisListAsync();
        Task<BacSi> GetBacSiById(int id);
        Task<BacSi> AddBacSiAsync(BacSi benh);
        Task<BacSi> UpdateBacSi(BacSi benh);
        Task<BacSi> DeleteBacSi(BacSi benh);
    }
}
