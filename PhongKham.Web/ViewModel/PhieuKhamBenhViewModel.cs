using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.ViewModel
{
    public class PhieuKhamBenhViewModel
    {
        public DateTime dateTimeKhamBenh { get; set; }
        //Ai khám
        [Required(ErrorMessage = " Not null !")]
        public int BenhNhanId { get; set; }
        //khám bởi ai
        [Required]
        public int BacSiId { get; set; }
        //Tạo bởi ai
        [Required]
        public int NhanVienId { get; set; }
        //Loại bệnh
        [Required]
        public int BenhId { get; set; }
        public int TienKhamBenh { get; set; }
        public string GhiChu { get; set; }
    }

}
