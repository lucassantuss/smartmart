#pragma checksum "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daa99715248befd8b8b5481dbc8420b2b89e3aee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Acesso_Index), @"mvc.1.0.view", @"/Views/Acesso/Index.cshtml")]
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
#line 1 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\_ViewImports.cshtml"
using Projeto_Interdisciplinar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\_ViewImports.cshtml"
using Projeto_Interdisciplinar.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daa99715248befd8b8b5481dbc8420b2b89e3aee", @"/Views/Acesso/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa4981920921dbb93cddfef122e321ee0e832f5c", @"/Views/_ViewImports.cshtml")]
    public class Views_Acesso_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UsuarioViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Home/home-sobre.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Acesso/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
  
    ViewData["Title"] = "Controle de Acesso";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "daa99715248befd8b8b5481dbc8420b2b89e3aee4585", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "daa99715248befd8b8b5481dbc8420b2b89e3aee5699", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<br />\r\n<br />\r\n<h1><b>Controle de Acesso</b></h1>\r\n<br />\r\n<br />\r\n<table class=\"table table-striped col-md-12\">\r\n    <tr>\r\n        <th>FotoUsuario</th>\r\n        <th>LoginUsuario</th>\r\n        <th>Ações</th>\r\n    </tr>\r\n");
#nullable restore
#line 20 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
     foreach (UsuarioViewModel u in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td><img");
            BeginWriteAttribute("src", " src=\"", 501, "\"", 545, 2);
            WriteAttributeValue("", 507, "data:image/jpeg;base64,/", 507, 24, true);
#nullable restore
#line 23 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
WriteAttributeValue("", 531, u.FotoUsuario, 531, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Foto Usuário\" style=\"width: 20px; height: 20px\"></td>\r\n            <td>");
#nullable restore
#line 24 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
           Write(u.LoginUsuario);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 681, "\"", 715, 2);
            WriteAttributeValue("", 688, "/Acesso/Visualizar?id=", 688, 22, true);
#nullable restore
#line 26 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
WriteAttributeValue("", 710, u.Id, 710, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Visualizar</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 772, "\"", 800, 2);
            WriteAttributeValue("", 779, "/Acesso/Edit?id=", 779, 16, true);
#nullable restore
#line 27 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
WriteAttributeValue("", 795, u.Id, 795, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">Editar</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 853, "\"", 891, 3);
            WriteAttributeValue("", 860, "javascript:apagarUsuario(", 860, 25, true);
#nullable restore
#line 28 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
WriteAttributeValue("", 885, u.Id, 885, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 890, ")", 890, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Apagar</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 31 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Acesso\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<br />\r\n<br />\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UsuarioViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
