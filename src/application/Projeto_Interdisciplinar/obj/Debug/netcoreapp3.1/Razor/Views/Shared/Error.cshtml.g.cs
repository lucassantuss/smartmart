#pragma checksum "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb40c22064363e06769d8c8e26eb7d97f3968d85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb40c22064363e06769d8c8e26eb7d97f3968d85", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"678544a5e5799dcd7feb130b242ea914d904ae08", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Erro";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2 class=\"text-danger\">Um erro ocorreu durante o processamento da sua requisição. </h2>\n<br />\n<p>\n    <strong>Detalhes do erro: </strong> <code> ");
#nullable restore
#line 8 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Shared\Error.cshtml"
                                          Write(Model.Erro);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </code>\n</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591