using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using PhongKham.Web.Services;

namespace PhongKham.Web.Pages.QLHoaDon
{
    [Authorize(Roles = "Admin,NhanVien")]
    public class IndexModel : PageModel
    {
        private readonly IHoaDonService _hoaDonService;
        private readonly IPhieuKhamBenhService _phieuKhamBenhService;
        private readonly IToaThuocService _toaThuocService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IHoaDonService hoaDonService, IPhieuKhamBenhService phieuKhamBenhService, IToaThuocService toaThuocService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _hoaDonService = hoaDonService ?? throw new ArgumentException(nameof(hoaDonService));
            _phieuKhamBenhService = phieuKhamBenhService ?? throw new ArgumentException(nameof(phieuKhamBenhService));
            _toaThuocService = toaThuocService ?? throw new ArgumentException(nameof(toaThuocService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<HoaDon> HoaDons { get; set; }
        public async Task OnGetAsync()
        {
            HoaDons = await _hoaDonService.GetHoaDonsListAsync();
        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            HoaDons = await _hoaDonService.GetHoaDonsListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableHoaDon",
                ViewData = new ViewDataDictionary<IEnumerable<HoaDon>>(ViewData, HoaDons)
            };
        }
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditHoaDon", new HoaDon()) });
            else
            {
                var thisLH = await _hoaDonService.GetHoaDonById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailHoaDon", thisLH) });
            }
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditHoaDon", new HoaDon()) });
            else
            {
                var thisLH = await _hoaDonService.GetHoaDonById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditHoaDon", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    /*
                     * TongThanhToan = Tien dich vu + Tong Tien Thuoc
                     */
                    /*
                     test 2 case
                    1: toaThuocId = null
                   2: toaThuocId != null
                     */
                    if(hoaDon.ToaThuocId != 0)
                    {
                        var tienThuoc = await _toaThuocService.GetToaThuocById(hoaDon.ToaThuocId ?? 0);

                        var tienKham = await _phieuKhamBenhService.GetPhieuKhamBenhById(hoaDon.PhieuKhamBenhId);
                        var HD = new HoaDon
                        {
                            dateTimeHD = DateTime.Now,
                            PhieuKhamBenhId = hoaDon.PhieuKhamBenhId,
                            BenhNhanId = hoaDon.BenhNhanId,
                            ToaThuocId = hoaDon.ToaThuocId,
                            TongThanhToan = tienKham.TienKhamBenh + tienThuoc.TongTienThuoc

                        };
                        await _hoaDonService.AddHoaDonAsync(HD);
                        await _unitOfWork.CompleteAsync();
                    }
                    else
                    {
                        

                        var tienKham = await _phieuKhamBenhService.GetPhieuKhamBenhById(hoaDon.PhieuKhamBenhId);
                        var HD = new HoaDon
                        {
                            dateTimeHD = DateTime.Now,
                            PhieuKhamBenhId = hoaDon.PhieuKhamBenhId,
                            BenhNhanId = hoaDon.BenhNhanId,
                            ToaThuocId = null,
                            TongThanhToan = tienKham.TienKhamBenh

                        };
                        await _hoaDonService.AddHoaDonAsync(HD);
                        await _unitOfWork.CompleteAsync();
                    }
              
                }
                else
                {
                    await _hoaDonService.UpdateHoaDon(hoaDon);
                    await _unitOfWork.CompleteAsync();
                }
                HoaDons = await _hoaDonService.GetHoaDonsListAsync();
                var html = await _renderService.ToStringAsync("_TableHoaDon", HoaDons);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditHoaDon", HoaDons);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
    }
}
