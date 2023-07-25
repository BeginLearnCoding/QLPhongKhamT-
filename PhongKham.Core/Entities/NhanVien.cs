using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class NhanVien 
    {
        [Key]
        public int Id { get; set; }
        public string tenNhanVien { get; set; }
        public int sdtNV { get; set; }
        public string dChiNV { get; set; }
        public ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; } = new List<PhieuKhamBenh>();
    }
}
