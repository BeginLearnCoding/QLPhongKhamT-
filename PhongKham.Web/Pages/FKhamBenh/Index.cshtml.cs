using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Web.Interface;
using PhongKham.Web.Services;
using PhongKham.Web.ViewModel;

namespace PhongKham.Web.Pages.FKhamBenh
{
    
    [Authorize(Roles = "NhanVien,BacSi")]
    public class IndexModel : PageModel
    {
        private readonly IPhieuKhamBenhService _phieuKhamBenhService;
        //Tạo bệnh để truyền vào
        private readonly IBenhService _benhService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IPhieuKhamBenhService phieuKhamBenhService, IBenhService benhService, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _phieuKhamBenhService = phieuKhamBenhService ?? throw new ArgumentException(nameof(phieuKhamBenhService));
            _benhService = benhService ?? throw new ArgumentException(nameof(benhService));
            _unitOfWork = unitOfWork;
            _renderService = renderService;

        }

        public IEnumerable<PhieuKhamBenh> PhieuKhamBenhs { get; set; }
        public void OnGet()
        {

        }
        /*
        public async Task OnGetAsync()
        {
            PhieuKhamBenhs = await _phieuKhamBenhService.GetPhieuKhamBenhsListAsync(bs => bs.bacSi, lh => lh.nhanVien, bn => bn.benhNhan, b => b.Benh);
        }
        */
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            PhieuKhamBenhs = await _phieuKhamBenhService.GetPhieuKhamBenhsListAsync(bs => bs.BacSi, lh => lh.NhanVien, bn => bn.BenhNhan, b => b.Benh);
            return new PartialViewResult
            {
                ViewName = "_TablePhieuKhamBenh",
                ViewData = new ViewDataDictionary<IEnumerable<PhieuKhamBenh>>(ViewData, PhieuKhamBenhs)
            };
        }


        public async Task<JsonResult> OnGetDetailAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditPhieuKhamBenh", new PhieuKhamBenh()) });
            else
            {
                var thisLH = await _phieuKhamBenhService.GetPhieuKhamBenhById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_DetailPhieuKhamBenh", thisLH) });
            }
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
            {
                var benhs = await _benhService.GetBenhsListAsync();
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditPhieuKhamBenh", new PhieuKhamBenh()) });
            }

            else
            {
                var thisLH = await _phieuKhamBenhService.GetPhieuKhamBenhById(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEditPhieuKhamBenh", thisLH) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, PhieuKhamBenh phieuKhamBenh)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _phieuKhamBenhService.AddPhieuKhamBenhAsync(phieuKhamBenh);
                    await _unitOfWork.CompleteAsync();

                }
                else
                {
                    await _phieuKhamBenhService.UpdatePhieuKhamBenh(phieuKhamBenh);
                    await _unitOfWork.CompleteAsync();
                }
                PhieuKhamBenhs = await _phieuKhamBenhService.GetPhieuKhamBenhsListAsync();
                var html = await _renderService.ToStringAsync("_TablePhieuKhamBenh", PhieuKhamBenhs);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEditPhieuKhamBenh", phieuKhamBenh);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var phieuKhamBenh = await _phieuKhamBenhService.GetPhieuKhamBenhById(id);
            await _phieuKhamBenhService.DeletePhieuKhamBenh(phieuKhamBenh);
            await _unitOfWork.CompleteAsync();
            PhieuKhamBenhs = await _phieuKhamBenhService.GetPhieuKhamBenhsListAsync();
            var html = await _renderService.ToStringAsync("_TablePhieuKhamBenh", PhieuKhamBenhs);
            return new JsonResult(new { isValid = true, html = html });
        }


    }
}
