#pragma checksum "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\CreateActivity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c02daa14b7e7c7b75cc9ca8d432e750d31336c1b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Student_Views_CreateActivity), @"mvc.1.0.view", @"/Areas/Student/Views/CreateActivity.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c02daa14b7e7c7b75cc9ca8d432e750d31336c1b", @"/Areas/Student/Views/CreateActivity.cshtml")]
    public class Areas_Student_Views_CreateActivity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Likhachev.Pgas.Services.Dtos.ActivityDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\CreateActivity.cshtml"
  
    ViewData["Title"] = "Добавления достижения";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Добавление достижения</h1>
<ul class=""nav nav-tabs"" id=""publishment-types"" role=""tablist"">
    <li class=""nav-item"">
        <a class=""nav-link active"" id=""flat-tab"" data-toggle=""tab"" href=""#flat"" role=""tab"" aria-controls=""flat"" aria-selected=""true"">Творческое достижение</a>
    </li>
    <li class=""nav-item"">
        <a class=""nav-link"" id=""room-tab"" data-toggle=""tab"" href=""#room"" role=""tab"" aria-controls=""characteristics"" aria-selected=""false"">Авторская работа</a>
    </li>
</ul>
<div class=""tab-content"" id=""product-content"">
    <div class=""tab-pane fade show active"" id=""flat"" role=""tabpanel"" aria-labelledby=""flat-tab""></div>
    <div class=""tab-pane fade"" id=""room"" role=""tabpanel"" aria-labelledby=""characteristics-tab""></div>
</div>
<br />
<div class=""col-md-4"">
    <section>
        <form asp-action=""CreateActivity"" asp-controller=""Activity"" method=""post"" enctype=""multipart/form-data"" asp-anti-forgery=""true"">
            ");
#nullable restore
#line 23 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\CreateActivity.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            <div>
                <div>
                    <input asp-for=""ActivityType"" id=""activity_type"" type=""hidden"" value=""1"" />
                </div>
                <div>
                    <label asp-for=""ActivityName"">Наименование достижения</label><br />
                    <input type=""text"" asp-for=""ActivityName"" class=""form-control"" />
                    <span asp-validation-for=""ActivityName"" />
                </div><br />
                <div>
                    <label asp-for=""Date"">Дата достижения</label><br />
                    <input type=""date"" asp-for=""Date"" class=""form-control"" />
                    <span asp-validation-for=""Date"" />
                </div><br />
                <div>
                    <label asp-for=""PinnedFile"">Прикрепите файл с подтверждением</label><br />
                    <input type=""file"" asp-for=""PinnedFile"" class=""form-control"" />
                    <span asp-validation-for=""PinnedFile"" />
                </div><br />
         ");
            WriteLiteral("       <div id=\"specifications\">\r\n");
#nullable restore
#line 44 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\CreateActivity.cshtml"
                       await Html.RenderPartialAsync("_Achievement");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
                <br />
                <div>
                    <input type=""submit"" value=""Добавить достижение"" class=""btn btn-outline-dark"" />
                </div>
            </div>
        </form>
    </section>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#flat-tab').click(function (e) {
                e.preventDefault();
                document.getElementById(""activity_type"").value = '1';
                $('#specifications').load('");
#nullable restore
#line 62 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\CreateActivity.cshtml"
                                      Write(Url.Action("_Achievement", "Activity"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
            });
        });

        $(document).ready(function () {
            $('#room-tab').click(function (e) {
                e.preventDefault();
                document.getElementById(""activity_type"").value = '2';
                $('#specifications').load('");
#nullable restore
#line 70 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\CreateActivity.cshtml"
                                      Write(Url.Action("_AuthorWork", "Activity"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            });\r\n         });\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Likhachev.Pgas.Services.Dtos.ActivityDto> Html { get; private set; }
    }
}
#pragma warning restore 1591