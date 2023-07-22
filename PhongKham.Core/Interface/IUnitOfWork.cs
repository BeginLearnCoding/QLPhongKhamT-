using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //IPhieuTiemPhongRepository PhieuTiemPhongs { get; }
        Task<int> CompleteAsync();
        // Task<int> Commit();
    }
}
