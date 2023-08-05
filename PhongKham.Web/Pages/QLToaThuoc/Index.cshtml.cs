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

namespace PhongKham.Web.Pages.QLToaThuoc
{
    [Authorize(Roles = "BacSi")]
    [Authorize(Roles = "NhanVien")]
    public class IndexModel : PageModel
    {
        private readonly IToaThuocService _toaThuocService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IToaThuocService toaThuocService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _toaThuocService = toaThuocService ?? throw new ArgumentException(nameof(toaThuocService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<ToaThuoc> toaThuocs { get; set; }
        public void OnGet()
        {

        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            toaThuocs = await _toaThuocService.GetToaThuocsListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableToaThuoc",
                ViewData = new ViewDataDictionary<IEnumerable<ToaThuoc>>(ViewData, toaThuocs)
            };
        }
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditToaThuoc", new ToaThuoc()) });
            else
            {
                var thisLH = await _toaThuocService.GetToaThuocById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailToaThuoc", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var thuoc = await _toaThuocService.GetToaThuocById(id);
            await _toaThuocService.DeleteToaThuoc(thuoc);
            await _unitOfWork.CompleteAsync();
            toaThuocs = await _toaThuocService.GetToaThuocsListAsync();
            var html = await _renderService.ToStringAsync("_TableToaThuoc", toaThuocs);
            return new JsonResult(new { isValid = true, html = html });
        }

    }
}
