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

namespace PhongKham.Web.Pages.QLThuoc
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IThuocService _thuocService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IThuocService thuocService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _thuocService = thuocService ?? throw new ArgumentException(nameof(thuocService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

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
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditThuoc", new Thuoc()) });
            else
            {
                var thisLH = await _thuocService.GetThuocById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailThuoc", thisLH) });
            }
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditThuoc", new Thuoc()) });
            else
            {
                var thisLH = await _thuocService.GetThuocById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditThuoc", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _thuocService.AddThuocAsync(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    await _thuocService.UpdateThuoc(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                Thuocs = await _thuocService.GetThuocsListAsync();
                var html = await _renderService.ToStringAsync("_TableThuoc", Thuocs);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditThuoc", thuoc);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var thuoc = await _thuocService.GetThuocById(id);
            await _thuocService.DeleteThuoc(thuoc);
            await _unitOfWork.CompleteAsync();
            Thuocs = await _thuocService.GetThuocsListAsync();
            var html = await _renderService.ToStringAsync("_TableThuoc", Thuocs);
            return new JsonResult(new { isValid = true, html = html });
        }


    }
}
