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

namespace PhongKham.Web.Pages.QLBenh
{
    [Authorize(Roles = "NhanVien,Admin")]
    public class IndexModel : PageModel
    {
        private readonly IBenhService _benhService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IBenhService benhService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _benhService = benhService ?? throw new ArgumentException(nameof(benhService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<Benh> Benhs { get; set; }
        public async Task OnGetAsync()
        {
            Benhs = await _benhService.GetBenhsListAsync();
        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Benhs = await _benhService.GetBenhsListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableBenh",
                ViewData = new ViewDataDictionary<IEnumerable<Benh>>(ViewData, Benhs)
            };
        }
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBenh", new Benh()) });
            else
            {
                var thisLH = await _benhService.GetBenhById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailBenh", thisLH) });
            }
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBenh", new Benh()) });
            else
            {
                var thisLH = await _benhService.GetBenhById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBenh", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Benh thuoc)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _benhService.AddBenhAsync(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    await _benhService.UpdateBenh(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                Benhs = await _benhService.GetBenhsListAsync();
                var html = await _renderService.ToStringAsync("_TableBenh", Benhs);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditBenh", thuoc);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var thuoc = await _benhService.GetBenhById(id);
            await _benhService.DeleteBenh(thuoc);
            await _unitOfWork.CompleteAsync();
            Benhs = await _benhService.GetBenhsListAsync();
            var html = await _renderService.ToStringAsync("_TableBenh", Benhs);
            return new JsonResult(new { isValid = true, html = html });
        }


    }
}
