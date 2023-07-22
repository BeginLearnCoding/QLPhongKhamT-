using PhongKham.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.ViewModel
{
    public class ListThuocCart
    {
        public List<ThuocCart> CartItems { get; set; }
        public int TotalAmount()
        {

            return CartItems.Sum(i => i.Thuoc.DonGia * i.Quantity);

        }
        public ListThuocCart()
        {
            CartItems = new List<ThuocCart>();
        }
    }

    public class ThuocCart
    {
        public int Quantity { get; set; }
        public int ThuocId { get; set; }
        public Thuoc Thuoc { get; set; }
        public int Price { get; set; }

    }
}
