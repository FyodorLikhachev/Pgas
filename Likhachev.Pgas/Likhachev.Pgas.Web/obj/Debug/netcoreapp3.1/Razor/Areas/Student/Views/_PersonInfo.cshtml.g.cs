#pragma checksum "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3f462b1649325d8a110b1233ea6007dc329d273"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Student_Views__PersonInfo), @"mvc.1.0.view", @"/Areas/Student/Views/_PersonInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3f462b1649325d8a110b1233ea6007dc329d273", @"/Areas/Student/Views/_PersonInfo.cshtml")]
    public class Areas_Student_Views__PersonInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Likhachev.Pgas.Services.Dtos.RegistrationAccountDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
  
    Layout = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Регистрация</h2>\r\n<div class=\"col-md-4\">\r\n    <section>\r\n        <div>\r\n            <p>Ваше имя: ");
#nullable restore
#line 10 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
                    Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n        <div>\r\n            <p>Ваша фамилия: ");
#nullable restore
#line 13 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
                        Write(Model.UserSecondName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n        <div>\r\n            <p>Ваше отчество: ");
#nullable restore
#line 16 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
                         Write(Model.UserMiddleName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n        <div>\r\n            <p>Ваш логин: ");
#nullable restore
#line 19 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
                     Write(Model.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n        <div>\r\n            <p>Ваш факультет: ");
#nullable restore
#line 22 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
                         Write(Model.FacultyName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n        <div>\r\n            <p>Ваша учебная группа: ");
#nullable restore
#line 25 "C:\Users\Fyodor Likhachev\source\repos\Likhachev.Pgas\Likhachev.Pgas.Web\Areas\Student\Views\_PersonInfo.cshtml"
                               Write(Model.StudyGroup);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n    </section>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Likhachev.Pgas.Services.Dtos.RegistrationAccountDto> Html { get; private set; }
    }
}
#pragma warning restore 1591