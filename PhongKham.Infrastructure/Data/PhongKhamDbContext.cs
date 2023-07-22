using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Infrastructure.Data
{
    /*
    public class PhongKhamDbContext : IdentityDbContext<IdentityUser>
    {
        public PhongKhamDbContext(DbContextOptions<PhongKhamDbContext> options) : base(options)
        {

        }

        public DbSet<Benh> benhs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<ToaThuoc> toaThuocs { get; set; }
        public DbSet<Thuoc> thuocs { get; set; }
        public DbSet<ChiTietToaThuoc> chiTietToaThuocs { get; set; }
        public DbSet<BacSi> bacSis { get; set; }
        public DbSet<BenhNhan> benhNhans { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<PhieuKhamBenh> phieuKhamBenhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }*/
    public class PhongKhamDbContext : DbContext
    {
        public PhongKhamDbContext(DbContextOptions<PhongKhamDbContext> options) : base(options)
        {

        }

        public DbSet<Benh> benhs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<ToaThuoc> toaThuocs { get; set; }
        public DbSet<Thuoc> thuocs { get; set; }
        public DbSet<ChiTietToaThuoc> chiTietToaThuocs { get; set; }
        public DbSet<BacSi> bacSis { get; set; }
        public DbSet<BenhNhan> benhNhans { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        public DbSet<PhieuKhamBenh> phieuKhamBenhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    
    }
}
