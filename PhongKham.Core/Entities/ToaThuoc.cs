using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhongKham.Core.Entities
{
    public class ToaThuoc
    {
        [Key]
        public int Id { get; set; }
        public DateTime dataTimeToaThuoc { get; set; }
        public int TongTienThuoc { get; set; }
        public string GhiChu { get; set; }

        public int PhieuKhamBenhId { get; set; }
        public PhieuKhamBenh PhieuKhamBenh { get; set; } = null!;


        public HoaDon? HoaDon { get; set; }

        public ICollection<ChiTietToaThuoc> chiTietToaThuocs { get; set; }
    }
}