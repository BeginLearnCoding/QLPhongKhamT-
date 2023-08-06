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

namespace PhongKham.Web.Pages.QLNhanVien
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly INhanVienService _nhanVienService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(INhanVienService nhanVienService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _nhanVienService = nhanVienService ?? throw new ArgumentException(nameof(nhanVienService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<NhanVien> NhanViens { get; set; }
        public async Task OnGetAsync()
        {
            NhanViens = await _nhanVienService.GetNhanViensListAsync();
        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            NhanViens = await _nhanVienService.GetNhanViensListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableNhanVien",
                ViewData = new ViewDataDictionary<IEnumerable<NhanVien>>(ViewData, NhanViens)
            };
        }
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditNhanVien", new NhanVien()) });
            else
            {
                var thisLH = await _nhanVienService.GetNhanVienById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailNhanVien", thisLH) });
            }
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditNhanVien", new NhanVien()) });
            else
            {
                var thisLH = await _nhanVienService.GetNhanVienById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditNhanVien", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, NhanVien thuoc)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _nhanVienService.AddNhanVienAsync(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    await _nhanVienService.UpdateNhanVien(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                NhanViens = await _nhanVienService.GetNhanViensListAsync();
                var html = await _renderService.ToStringAsync("_TableNhanVien", NhanViens);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditNhanVien", thuoc);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var thuoc = await _nhanVienService.GetNhanVienById(id);
            await _nhanVienService.DeleteNhanVien(thuoc);
            await _unitOfWork.CompleteAsync();
            NhanViens = await _nhanVienService.GetNhanViensListAsync();
            var html = await _renderService.ToStringAsync("_TableNhanVien", NhanViens);
            return new JsonResult(new { isValid = true, html = html });
        }
    }

}
