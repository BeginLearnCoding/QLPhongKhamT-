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

        public int PhieuKhamBenhId { get; set; }
        public PhieuKhamBenh PhieuKhamBenh { get; set; } = null!;

        public int? ToaThuocId { get; set; }
        public ToaThuoc? ToaThuoc { get; set; }

        public int TongThanhToan { get; set; }
        
        
        public int BenhNhanId { get; set; }
        public BenhNhan BenhNhan { get; set; } = null!;
    }
}