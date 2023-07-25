using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class BacSi
    {
        [Key]
        public int Id { get; set; }
        public int sdtBS { get; set; }
        public string TenBacSi { get; set; }
        public string diaChiBS { get; set; }
        public ICollection<PhieuKhamBenh> PhieuKhamBenhs { get; } = new List<PhieuKhamBenh>();
    }
}
