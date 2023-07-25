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
            //PhieuKhamBenh key
            modelBuilder.Entity<BenhNhan>().HasMany(e => e.PhieuKhamBenhs).WithOne(e => e.BenhNhan).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BacSi>().HasMany(e => e.PhieuKhamBenhs).WithOne(e => e.BacSi).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<NhanVien>().HasMany(e => e.PhieuKhamBenhs).WithOne(e => e.NhanVien).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PhieuKhamBenh>().HasOne(e => e.Benh).WithMany().HasForeignKey(e => e.BenhId).IsRequired();
            modelBuilder.Entity<HoaDon>().HasOne(e => e.PhieuKhamBenh).WithOne(e => e.HoaDon).HasForeignKey<HoaDon>(e => e.PhieuKhamBenhId).IsRequired();
            //modelBuilder.Entity<HoaDon>().HasOne(e => e.ToaThuoc).WithOne(e => e.HoaDon).HasForeignKey<ToaThuoc>(e => e.HoaDonId).IsRequired(false);
            // Hóa đơn có thể có toa thuốc hoặc không.
            modelBuilder.Entity<HoaDon>().HasOne(p => p.ToaThuoc).WithOne(e => e.HoaDon).HasForeignKey<HoaDon>(e => e.ToaThuocId).IsRequired(false);
            // Toa thuốc cần có PKB
            modelBuilder.Entity<ToaThuoc>().HasOne(e => e.PhieuKhamBenh).WithOne(e => e.ToaThuoc).HasForeignKey<ToaThuoc>(e => e.PhieuKhamBenhId).IsRequired();


        }

    }
}
