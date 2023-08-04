using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using PhongKham.Web.Services;
using PhongKham.Web.ViewModel;

namespace PhongKham.Web.Pages.QLToaThuoc
{
    [Authorize(Roles = "BacSi")]
    public class CreateToaThuocModel : PageModel
    {
        private readonly IThuocService _thuocService;
        private readonly IToaThuocService _toaThuocService;
        private readonly IChiTietToaThuocService _chiTietToaThuocService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        public const string SessionKey = "Cart";
        public CreateToaThuocModel(IThuocService thuocService, IToaThuocService toaThuocService, IUnitOfWork unitOfWork, IRazorRenderService renderService, IChiTietToaThuocService chiTietToaThuocService)
        {
            _thuocService = thuocService ?? throw new ArgumentException(nameof(thuocService));
            _toaThuocService = toaThuocService ?? throw new ArgumentException(nameof(toaThuocService));
            _chiTietToaThuocService = chiTietToaThuocService ?? throw new ArgumentException(nameof(chiTietToaThuocService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        [BindProperty]
        public ToaThuocViewModel addToaThuoc { get; set; }
        public IEnumerable<Thuoc> Thuocs { get; set; }
        public async Task OnGetAsync()
        {
            Thuocs = await _thuocService.GetThuocsListAsync();
        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Thuocs = await _thuocService.GetThuocsListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableThuoc",
                ViewData = new ViewDataDictionary<IEnumerable<Thuoc>>(ViewData, Thuocs)
            };
        }

        public PartialViewResult OnGetViewToaThuocPartial()
        {
            var cartItems = GetListThuocCart();
            ViewData["CartItems"] = cartItems;

            return new PartialViewResult
            {
                ViewName = "_ListThuocCart",
                ViewData = new ViewDataDictionary<ListThuocCart>(ViewData, cartItems)
            };
        }

        private void SaveCartSession(ListThuocCart cart)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(cart);
            session.SetString(SessionKey, jsoncart);
        }

        private ListThuocCart GetListThuocCart()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(SessionKey);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<ListThuocCart>(jsoncart);
            }
            return new ListThuocCart();
        }

        public async Task<IActionResult> OnPostAddToListThuocCart(int thuocId)
        {
            var thuoc = await _thuocService.GetThuocById(thuocId);

            // Xử lý đưa vào Cart ...
            var cart = GetListThuocCart();
            var cartItem = cart.CartItems.Find(p => p.Thuoc.Id == thuocId);
            if (cartItem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartItem.Quantity++;
            }
            else
            {
                //  Thêm mới
                cart.CartItems.Add(new ThuocCart() { Quantity = 1, Thuoc = thuoc });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return Page();
        }
        public async Task<IActionResult> OnPostRemoveCartItems(int thuocId)
        {
            var cart = GetListThuocCart();
            var thuoc = await _thuocService.GetThuocById(thuocId);
            var cartItem = cart.CartItems.Find(p => p.Thuoc.Id == thuocId);
            if (cartItem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.CartItems.Remove(cartItem);
            }

            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return Page();
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(SessionKey);
        }
        public async Task<IActionResult> OnPostCreateToaThuoc(ToaThuoc toaThuoc)
        {

            if (ModelState.IsValid)
            {
                /*
                var phieuKhamBenhId = int.Parse(Request.Form["PhieuKhamBenhId"]);
                toaThuoc.PhieuKhamBenhId = phieuKhamBenhId;
                */
                var listToaThuoc = GetListThuocCart();
                var _toathuoc = new ToaThuoc
                {
                    dataTimeToaThuoc = DateTime.Now,
                    TongTienThuoc = listToaThuoc.TotalAmount(),
                    PhieuKhamBenhId = toaThuoc.PhieuKhamBenhId,
                    GhiChu = toaThuoc.GhiChu
                };

                await _toaThuocService.AddToaThuocAsync(_toathuoc);
                await _unitOfWork.CompleteAsync();

                foreach (var thuoc in listToaThuoc.CartItems)
                {
                    var chiTietThuoc = new ChiTietToaThuoc
                    {
                        ToaThuocId = _toathuoc.Id,
                        ThuocId = thuoc.Thuoc.Id,
                        quantity = thuoc.Quantity
                    };
                    await _chiTietToaThuocService.AddChiTietToaThuocAsync(chiTietThuoc);
                    await _unitOfWork.CompleteAsync();
                }
                ClearCart();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
