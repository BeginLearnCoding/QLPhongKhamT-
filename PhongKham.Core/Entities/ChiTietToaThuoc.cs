using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhongKham.Core.Entities
{
    public class ChiTietToaThuoc
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ToaThuocId")]
        public int ToaThuocId { get; set; }
        public ToaThuoc ToaThuoc { get; set; }
        [ForeignKey("ThuocId")]
        public int ThuocId { get; set; }
        public Thuoc Thuoc { get; set; }
        public int quantity { get; set; }

    }
}