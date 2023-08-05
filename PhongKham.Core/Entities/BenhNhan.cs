using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class BenhNhan
    {
        [Key]
        public int Id { get; set; }
        public string TenBenhNhan { get; set; }
        public GioiTinh gioiTinh { get; set; }
        public string sdtBN { get; set; }
        public string dChiBN { get; set; }
        public ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; } = new List<PhieuKhamBenh>();
        public ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();
    }

    public enum GioiTinh
    {
        Nam = 1,Nu = 2
    }
}
