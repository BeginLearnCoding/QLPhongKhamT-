using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.ViewModel
{
    public class ToaThuocViewModel
    {
        public DateTime dataTimeToaThuoc { get; set; }
        public int TongTienThuoc { get; set; }
        public string GhiChu { get; set; }
        public int PhieuKhamBenhId { get; set; }
        //public PhieuKhamBenh phieuKhamBenh { get; set; }
        public ICollection<ChiTietToaThuocViewModel> chiTietToaThuocs { get; set; }
    }

    public class ChiTietToaThuocViewModel
    {
        public int ToaThuocId { get; set; }
        public ToaThuocViewModel ToaThuoc { get; set; }

        public int ThuocId { get; set; }
        public ThuocViewModel Thuoc { get; set; }
        public int quantity { get; set; }
    }

    public class ThuocViewModel
    {
        public string TenThuoc { get; set; }
        public int DonGia { get; set; }
        public DonVi donVi { get; set; }
        public CachDung cachDung { get; set; }
    }

    public enum CachDung
    {
        CachDung1 = 1, CachDung2 = 2, CachDung3 = 3, CachDung4 = 4
    }

    public enum DonVi
    {
        Vien = 1, Chai = 2
    }
}
