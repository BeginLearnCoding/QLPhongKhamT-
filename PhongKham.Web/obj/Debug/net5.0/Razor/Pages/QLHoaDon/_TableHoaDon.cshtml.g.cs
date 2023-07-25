#pragma checksum "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c07dd00d920a2e1cf01c4c1cff4cc57edce98a1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(PhongKham.WebApp.Pages.QLHoaDon.Pages_QLHoaDon__TableHoaDon), @"mvc.1.0.view", @"/Pages/QLHoaDon/_TableHoaDon.cshtml")]
namespace PhongKham.WebApp.Pages.QLHoaDon
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
using PhongKham.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c07dd00d920a2e1cf01c4c1cff4cc57edce98a1b", @"/Pages/QLHoaDon/_TableHoaDon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d73166db3a9bb39291862003c1d43739c9b01c9", @"/Pages/_ViewImports.cshtml")]
    public class Pages_QLHoaDon__TableHoaDon : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HoaDon>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- Basic Bootstrap Table -->
<div class=""card"">
    <h5 class=""card-header"">Danh sách Hóa đơn</h5>
    <div class=""table-responsive text-nowrap"">
        <table class=""table"" id=""lichHenTables"">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Ngày xuất HĐ</th>
                    <th>Mã Phiếu khám bệnh</th>
                    <th>Mã bệnh bệnh nhân</th>
                    <th>Mã toa thuốc</th>
                    <th>Tổng thanh toán</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody class=""table-border-bottom-0"">
");
#nullable restore
#line 21 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                 if (Model.Count() != 0)
                {


                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                     foreach (var hd in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td><i class=\"fab fa-angular fa-lg text-danger me-3\"></i> <strong>");
#nullable restore
#line 28 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                                                                                 Write(hd.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></td>\r\n                    <td>");
#nullable restore
#line 29 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                   Write(hd.dateTimeHD);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                   Write(hd.PhieuKhamBenhId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                   Write(hd.BenhNhanId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                   Write(hd.ToaThuocId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                   Write(hd.TongThanhToan);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
              
                    <td>
                        <div class=""dropdown"">
                            <button type=""button"" class=""btn p-0 dropdown-toggle hide-arrow""  data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                <i class=""bx bx-dots-vertical-rounded""></i>
                            </button>
                            <div class=""dropdown-menu"">
                                <a class=""dropdown-item btn btn-outline-primary""");
            BeginWriteAttribute("onclick", " onclick=\"", 1706, "\"", 1778, 6);
            WriteAttributeValue("", 1716, "jQueryModalGet(\'?handler=Detail&id=", 1716, 35, true);
#nullable restore
#line 41 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
WriteAttributeValue("", 1751, hd.Id, 1751, 6, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1757, "\',\'Chi", 1757, 6, true);
            WriteAttributeValue(" ", 1763, "tiết", 1764, 5, true);
            WriteAttributeValue(" ", 1768, "hóa", 1769, 4, true);
            WriteAttributeValue(" ", 1772, "đơn\')", 1773, 6, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                    <i class=""bx bx-edit-alt me-1""></i>
                                    Chi tiết
                                </a>
                            </div>
                        </div>
                    </td>
                </tr>
");
#nullable restore
#line 49 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\XT-1\CNPM\CNPM-PhongKham-2\PhongKham.Web\Pages\QLHoaDon\_TableHoaDon.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n<!--/ Basic Bootstrap Table -->\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\"#lichHenTables\").DataTable();\r\n    });\r\n</script>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HoaDon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
