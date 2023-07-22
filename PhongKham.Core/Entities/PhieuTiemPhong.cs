using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class PhieuTiemPhong
    {
     
        public int Id { get; set; }

        public string TenTiemPhong { get; set; }

        public DateTime dateTimeTiemPhong { get; set; }
        /*
        [ForeignKey("LichHenId")]
        public int LichHenId { get; set; }
        public LichHen lichHen { get; set; }
        */

        public int ThanhTien { get; set; }
        //thành tiền không là poperty mà là một hằng

        public string Ghichu { get; set; }
    }
}
