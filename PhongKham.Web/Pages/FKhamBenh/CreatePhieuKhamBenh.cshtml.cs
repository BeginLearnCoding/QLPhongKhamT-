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
    [Authorize(Roles = "BacSi")]
    [Authorize(Roles = "NhanVien")]
    public class CreatePhieuKhamBenhModel : PageModel
    {
        private readonly IPhieuKhamBenhService _phieuKhamBenhService;
        private readonly IUnitOfWork _unitOfWork;
        //Tạo bệnh để truyền vào
        private readonly IBenhService _benhService;
        //private readonly IRazorRenderService _renderService;

        public CreatePhieuKhamBenhModel(IPhieuKhamBenhService phieuKhamBenhService, IBenhService benhService, IUnitOfWork unitOfWork) //IRazorRenderService renderService)
        {
            _phieuKhamBenhService = phieuKhamBenhService ?? throw new ArgumentException(nameof(phieuKhamBenhService));
            _benhService = benhService ?? throw new ArgumentException(nameof(benhService));
            _unitOfWork = unitOfWork;
            //_renderService = renderService;

        }
        /*
        public async Task<PartialViewResult> OnGetViewBenhPartial()
        {
            var benhs = await _benhService.GetBenhsListAsync();

            return new PartialViewResult
            {
                ViewName = "_benhList",
                ViewData = new ViewDataDictionary<IEnumerable<Benh>>(ViewData, benhs)
            };
        }
        */
        [BindProperty]
        //public IEnumerable<PhieuKhamBenh> PhieuKhamBenhs { get; set; }
        public PhieuKhamBenhViewModel AddPKB { get; set; }

    
        public async Task<IActionResult> OnGetAsync()
        {
            var benhs = await _benhService.GetBenhsListAsync();
            ViewData["Benh"] = new SelectList(benhs, "Id", "tenBenh");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(PhieuKhamBenh phieuKhamBenh)
        {
            if (ModelState.IsValid)
            {


                var PKB = new PhieuKhamBenh
                {
                    dateTimeKhamBenh = DateTime.Now,
                    BenhNhanId = phieuKhamBenh.BenhNhanId,
                    BacSiId = phieuKhamBenh.BacSiId,
                    NhanVienId = phieuKhamBenh.NhanVienId,
                    BenhId = AddPKB.BenhId,
                    TienKhamBenh = phieuKhamBenh.TienKhamBenh,
                    GhiChu = phieuKhamBenh.GhiChu
                };

                await _phieuKhamBenhService.AddPhieuKhamBenhAsync(PKB);
                await _unitOfWork.CompleteAsync();
            }
            return Redirect("/FKhamBenh/Index");

        }
    }
}
