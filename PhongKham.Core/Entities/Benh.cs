using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongKham.Core.Entities
{
    public class Benh
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên bệnh không được trống !")]
        public string tenBenh { get; set; }
        public string MoTa { get; set; }
    }
}
