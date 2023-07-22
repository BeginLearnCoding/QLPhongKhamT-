using PhongKham.Core.Entities;
using PhongKham.Core.Interface.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IBenhRepository : IGenericRepository<Benh>
    {

        Task<IEnumerable<Benh>> GetBenhsListAsync();
        Task<Benh> GetBenhById(int id);
        Task<Benh> AddBenhAsync(Benh benh);
        Task<Benh> UpdateBenh(Benh benh);
        Task<Benh> DeleteBenh(Benh benh);
    }
}
