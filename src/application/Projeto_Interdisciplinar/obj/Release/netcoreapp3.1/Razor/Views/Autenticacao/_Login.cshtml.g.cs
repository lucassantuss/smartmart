#pragma checksum "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d494ea525a301198502963e3b8b6f2c1cde0f785"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Autenticacao__Login), @"mvc.1.0.view", @"/Views/Autenticacao/_Login.cshtml")]
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
#nullable restore
#line 1 "D:\Outros\Projeto_Interdisciplinar\Views\_ViewImports.cshtml"
using Projeto_Interdisciplinar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Outros\Projeto_Interdisciplinar\Views\_ViewImports.cshtml"
using Projeto_Interdisciplinar.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d494ea525a301198502963e3b8b6f2c1cde0f785", @"/Views/Autenticacao/_Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"678544a5e5799dcd7feb130b242ea914d904ae08", @"/Views/_ViewImports.cshtml")]
    public class Views_Autenticacao__Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UsuarioViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
 using (Html.BeginForm("FazLogin", "Autenticacao", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\n        ");
#nullable restore
#line 8 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
   Write(Html.LabelFor(model => model.LoginUsuario, labelText: "Usuário"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        ");
#nullable restore
#line 9 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
   Write(Html.TextBoxFor(model => model.LoginUsuario, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
            WriteLiteral("    <div class=\"form-group\">\n        ");
#nullable restore
#line 13 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
   Write(Html.LabelFor(model => model.SenhaUsuario, labelText: "Senha"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        ");
#nullable restore
#line 14 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
   Write(Html.PasswordFor(model => model.SenhaUsuario, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-primary\">Entrar</button>\n");
#nullable restore
#line 18 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 20 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
 if (!string.IsNullOrEmpty(ViewBag.MensagemErro))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">");
#nullable restore
#line 22 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
                               Write(ViewBag.MensagemErro);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 23 "D:\Outros\Projeto_Interdisciplinar\Views\Autenticacao\_Login.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UsuarioViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591