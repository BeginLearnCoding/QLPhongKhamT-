using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class PhieuXetNghiem
    {

        public int Id { get; set; }
        public string TenXetNghiem { get; set; }
        public DateTime dateTimeXetNghiem { get; set; }
        /*
     [ForeignKey("LichHenId")]
     public int LichHenId { get; set; }
     public LichHen lichHen { get; set; }
     */
        public KetQuaXetNghiem ketQuaXetNghiem { get; set; }
        public int ThanhTien { get; set; }
        public string GhiChu { get; set; }
    }

    public enum KetQuaXetNghiem
    {
        DuongTinh=1,AmTinh=2
    }
}
