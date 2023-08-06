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

namespace PhongKham.Web.Pages.QLBenhNhan
{
    [Authorize(Roles = "Admin,NhanVien")]
    public class IndexModel : PageModel
    {
        private readonly IBenhNhanService _benhNhanService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IBenhNhanService benhNhanService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _benhNhanService = benhNhanService ?? throw new ArgumentException(nameof(benhNhanService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<BenhNhan> BenhNhans { get; set; }
        public async Task OnGetAsync()
        {
            BenhNhans = await _benhNhanService.GetBenhNhansListAsync();
        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            BenhNhans = await _benhNhanService.GetBenhNhansListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableBenhNhan",
                ViewData = new ViewDataDictionary<IEnumerable<BenhNhan>>(ViewData, BenhNhans)
            };
        }
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBenhNhan", new BenhNhan()) });
            else
            {
                var thisLH = await _benhNhanService.GetBenhNhanById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailBenhNhan", thisLH) });
            }
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBenhNhan", new BenhNhan()) });
            else
            {
                var thisLH = await _benhNhanService.GetBenhNhanById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBenhNhan", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, BenhNhan thuoc)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _benhNhanService.AddBenhNhanAsync(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    await _benhNhanService.UpdateBenhNhan(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                BenhNhans = await _benhNhanService.GetBenhNhansListAsync();
                var html = await _renderService.ToStringAsync("_TableBenhNhan", BenhNhans);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditBenhNhan", thuoc);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var thuoc = await _benhNhanService.GetBenhNhanById(id);
            await _benhNhanService.DeleteBenhNhan(thuoc);
            await _unitOfWork.CompleteAsync();
            BenhNhans = await _benhNhanService.GetBenhNhansListAsync();
            var html = await _renderService.ToStringAsync("_TableBenhNhan", BenhNhans);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}
