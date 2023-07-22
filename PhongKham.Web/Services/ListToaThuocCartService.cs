using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PhongKham.Core.Entities;
using PhongKham.Web.Interface;
using PhongKham.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web.Services
{
    public class ListToaThuocCartService
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IThuocService _thuocService;

        public ListToaThuocCartService(IHttpContextAccessor httpContextAccessor, IThuocService thuocService)
        {
            _httpContextAccessor = httpContextAccessor;
            _thuocService = thuocService;
        }
        public ListThuocCart GetCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            var cart = session.GetString("Cart");
            if (cart != null)
            {
                return JsonConvert.DeserializeObject<ListThuocCart>("Cart");
            }

            return new ListThuocCart();
        }
        public void SetCart(ListThuocCart cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(cart);
            session.SetString("Cart", jsoncart);
        }
        public void AddItemToCart(ThuocCart item)
        {
            var cart = GetCart();

            // Check if item is already in cart
            //var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            var existingItem = cart.CartItems.FirstOrDefault(i => i.ThuocId == item.ThuocId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.CartItems.Add(item);
            }

            SetCart(cart);
        }

        public void RemoveItemFromCart(int thuocId)
        {
            var cart = GetCart();
            var item = cart.CartItems.FirstOrDefault(i => i.ThuocId == thuocId);

            if (item != null)
            {
                cart.CartItems.Remove(item);
                SetCart(cart);
            }
        }

        public void ClearCart()
        {
            var cart = new ListThuocCart();
            SetCart(cart);
        }
       
    }
}
