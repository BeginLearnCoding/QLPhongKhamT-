using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class LichHen
    {
        [Key]
        public int Id { get; set; }
        public string tenBenhNhan { get; set; }
        public BenhNhan BenhNhan { get; set; }
        public string tenLichHen { get; set; }
        public DateTime dateTimeLichHen { get; set; }
        public string GhiChu { get; set; }
        public PhieuKhamBenh? phieuKhamBenh { get; set; }
        //public DichVu DichVu { get; set; }
        //public ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; set; }
    }
    /*
    public enum DichVu
    {
        TiemPhong = 1, XetNghiem = 2, TuVan = 3, KhamBenh =4
    }
    */
}
