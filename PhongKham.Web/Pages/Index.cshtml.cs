using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhongKham.Core.Entities;
using PhongKham.Web.Interface;

namespace PhongKham.Web.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly IHoaDonService _hoaDonService;
        private readonly IPhieuKhamBenhService _phieuKhamBenhService;
        private readonly IToaThuocService _toaThuocService;
        public IndexModel(IHoaDonService hoaDonService, IPhieuKhamBenhService phieuKhamBenhService, IToaThuocService toaThuocService)
        {
            _hoaDonService = hoaDonService;
            _phieuKhamBenhService = phieuKhamBenhService;
            _toaThuocService = toaThuocService;
        }
        public int hoaDon { get; set; }
        public int toaThuoc { get; set; }
        public int phieuKhamBenh { get; set; }

        public IEnumerable<HoaDon> HoaDons { get; set; }
        public async Task OnGetAsync()
        {
            hoaDon = (await _hoaDonService.GetHoaDonsListAsync()).Count();
            toaThuoc = (await _toaThuocService.GetToaThuocsListAsync()).Count();
           phieuKhamBenh = (await _phieuKhamBenhService.GetPhieuKhamBenhsListAsync()).Count();

            HoaDons = await _hoaDonService.GetHoaDonsListAsync();
        }
    }
}
