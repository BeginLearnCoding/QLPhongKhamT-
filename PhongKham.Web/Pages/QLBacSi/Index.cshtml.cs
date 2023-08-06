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

namespace PhongKham.Web.Pages.QLBacSi
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IBacSiService _bacSiService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IBacSiService bacSiService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _bacSiService = bacSiService ?? throw new ArgumentException(nameof(bacSiService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<BacSi> BacSis { get; set; }
        public async Task OnGetAsync()
        {
            BacSis = await _bacSiService.GetBacSisListAsync();
        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            BacSis = await _bacSiService.GetBacSisListAsync();
            return new PartialViewResult
            {
                ViewName = "_TableBacSi",
                ViewData = new ViewDataDictionary<IEnumerable<BacSi>>(ViewData, BacSis)
            };
        }
        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBacSi", new BacSi()) });
            else
            {
                var thisLH = await _bacSiService.GetBacSiById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailBacSi", thisLH) });
            }
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBacSi", new BacSi()) });
            else
            {
                var thisLH = await _bacSiService.GetBacSiById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditBacSi", thisLH) });
            }
        }
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, BacSi thuoc)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _bacSiService.AddBacSiAsync(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                else
                {
                    await _bacSiService.UpdateBacSi(thuoc);
                    await _unitOfWork.CompleteAsync();
                }
                BacSis = await _bacSiService.GetBacSisListAsync();
                var html = await _renderService.ToStringAsync("_TableBacSi", BacSis);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditBacSi", thuoc);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var thuoc = await _bacSiService.GetBacSiById(id);
            await _bacSiService.DeleteBacSi(thuoc);
            await _unitOfWork.CompleteAsync();
            BacSis = await _bacSiService.GetBacSisListAsync();
            var html = await _renderService.ToStringAsync("_TableBacSi", BacSis);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}

