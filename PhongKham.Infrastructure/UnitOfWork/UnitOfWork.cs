using PhongKham.Core.Interface;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhongKhamDbContext _context;
        private bool disposed;
        public UnitOfWork(PhongKhamDbContext context)
        {
            //_context = context;
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //PhieuTiemPhongs = new PhieuTiemPhongRepository(_context);

        }
      

        //public IPhieuTiemPhongRepository PhieuTiemPhongs { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}
