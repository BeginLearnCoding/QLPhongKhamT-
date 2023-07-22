using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class PhieuTuVan
    {

        public int Id { get; set; }
        public string TenTuVan { get; set; }
        public DateTime dateTimeTuVan { get; set; }
        /*
     [ForeignKey("LichHenId")]
     public int LichHenId { get; set; }
     public LichHen lichHen { get; set; }
     */
        public LichHen lichHen { get; set; }
        public int ThanhTien { get; set; }
        public string GhiChu { get; set; }
    }
}
