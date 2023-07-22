using System.ComponentModel.DataAnnotations;

namespace PhongKham.Core.Entities
{
    public class Thuoc
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Không được để trống tên thuốc")]
        [Required]
        [MinLength(5)]
        public string TenThuoc { get; set; }
        //[Required(ErrorMessage = "Không được để Đơn giá thuốc")]
        [Required]
        public int DonGia { get; set; }   
        public DonVi donVi { get; set; }
        public CachDung cachDung { get; set; }
    }

    public enum CachDung
    {
        CachDung1 = 1,CachDung2 = 2,CachDung3 = 3,CachDung4 = 4
    }

    public enum DonVi
    {
        Vien = 1,Chai = 2
    }
}