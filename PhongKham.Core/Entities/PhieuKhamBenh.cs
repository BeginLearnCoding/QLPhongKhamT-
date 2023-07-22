using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class PhieuKhamBenh
    {
        [Key]
        public int Id { get; set; }
        public DateTime dateTimeKhamBenh { get; set; }
        //Ai khám
        [ForeignKey("BenhNhanId")]

        public int? BenhNhanId { get; set; }
        public BenhNhan benhNhan { get; set; }
        //khám bởi ai
        [ForeignKey("BacSiId")]

        public int? BacSiId { get; set; }
        public BacSi bacSi { get; set; }
        //Tạo bởi ai
        [ForeignKey("NhanVienId")]
        public int? NhanVienId { get; set; }
        public NhanVien nhanVien { get; set; }
        //Loại bệnh
        [ForeignKey("BenhId")]
        public int? BenhId { get; set; }
        public Benh Benh { get; set; }

        /*
               public ToaThuoc? toaThuoc { get; set; }
        public HoaDon? hoaDon { get; set; }
         */

        public int TienKhamBenh { get; set; }
        public string GhiChu { get; set; }
    }
}
