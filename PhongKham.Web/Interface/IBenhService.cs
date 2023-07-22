using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Interface
{
    public interface IBenhService
    {
        Task<IEnumerable<Benh>> GetBenhsListAsync();
        Task<Benh> GetBenhById(int id);
        Task<Benh> AddBenhAsync(Benh benh);
        Task<Benh> UpdateBenh(Benh benh);
        Task<Benh> DeleteBenh(Benh benh);
    }
}
