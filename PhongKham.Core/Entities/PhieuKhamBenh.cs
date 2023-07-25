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

        public int BenhNhanId { get; set; }
        public BenhNhan BenhNhan { get; set; } = null!;
        //khám bởi ai

        public int BacSiId { get; set; }
        public BacSi BacSi { get; set; } = null!;
        //Tạo bởi ai

        public int NhanVienId { get; set; }
        public NhanVien NhanVien { get; set; } = null!;
        //Loại bệnh

        public int BenhId { get; set; }
        public Benh Benh { get; set; }


        public HoaDon? HoaDon { get; set; }
        public ToaThuoc? ToaThuoc { get; set; }

        public int TienKhamBenh { get; set; }
        public string GhiChu { get; set; }
    }
}
