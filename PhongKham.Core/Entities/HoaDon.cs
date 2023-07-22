using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhongKham.Core.Entities
{
    public class HoaDon
    {
        public int Id { get; set; }
        public DateTime dateTimeHD { get; set; }
        
        [Required]
        [ForeignKey("PhieuKhamBenhId")]
        public int PhieuKhamBenhId { get; set; }
        public PhieuKhamBenh phieuKhamBenh { get; set; }
        
        [ForeignKey("ToaThuocId")]
        // public int? ToaThuocId { get; set; }
        public int? ToaThuocId { get; set; }
        public ToaThuoc toaThuoc { get; set; }

        public int TongThanhToan { get; set; }
        
        
        [Required]
        [ForeignKey("BenhNhanId")]
        public int BenhNhanId { get; set; }
        public BenhNhan benhNhan { get; set; }
    }
}