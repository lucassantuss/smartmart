#pragma checksum "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1949701762ffe38a0deb5451a246712222fcb073"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Carrinho_Index), @"mvc.1.0.view", @"/Views/Carrinho/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1949701762ffe38a0deb5451a246712222fcb073", @"/Views/Carrinho/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"678544a5e5799dcd7feb130b242ea914d904ae08", @"/Views/_ViewImports.cshtml")]
    public class Views_Carrinho_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ItensPedidoViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/carrinho.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/Carrinho/Carrinho.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/consulta.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
   Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<script src=\"https://code.jquery.com/jquery-3.6.0.min.js\"></script>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1949701762ffe38a0deb5451a246712222fcb0735020", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n<br />\n<h1>Carrinho de Compras</h1>\n<br />\n<center>\n    <label class=\"control-label\">Código do Carrinho</label>\n");
#nullable restore
#line 12 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
     if (@ViewBag.IdCarrinho != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input id=\"IdCarrinho\" class=\"form-control col-md-6\" placeholder=\"Digite o código apresentado no seu carrinho de compras físico\"");
            BeginWriteAttribute("value", " value=\"", 480, "\"", 507, 1);
#nullable restore
#line 14 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
WriteAttributeValue("", 488, ViewBag.IdCarrinho, 488, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\n");
#nullable restore
#line 15 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <input id=\"IdCarrinho\" class=\"form-control col-md-6\" placeholder=\"Digite o código apresentado no seu carrinho de compras físico\"/>\n");
#nullable restore
#line 19 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span id=\"alertIdCarrinho\" class=\"text-danger\"></span>\n    <br />\n    <label class=\"control-label\">Exemplo de código -> 123</label>\n    <br />\n    <br />\n    <button onclick=\"Pesquisar()\" class=\"btn btn-secondary\">Pesquisar</button>\n</center>\n<br />\n");
#nullable restore
#line 28 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
 if (@ViewBag.Visualizacao == true)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"fundo-vitrine\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1949701762ffe38a0deb5451a246712222fcb0738237", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        Há ");
#nullable restore
#line 32 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
      Write(ViewBag.TotalCarrinho);

#line default
#line hidden
#nullable disable
            WriteLiteral(" itens no carrinho.\n        <button type=\"button\" onclick=\"Visualizar()\" class=\"btn btn-link\">Visualizar</button>\n    </div>\n    <br />\n    <br />\n    <div class=\"fundo-vitrine\">\n        <ul class=\"ul-vitrine\">\n");
#nullable restore
#line 39 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
             foreach (var itensPedido in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"li-vitrine\">\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1415, "\"", 1471, 2);
            WriteAttributeValue("", 1422, "/Carrinho/Detalhes/?idItensPedido=", 1422, 34, true);
#nullable restore
#line 42 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
WriteAttributeValue("", 1456, itensPedido.Id, 1456, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                        <figure class=\"figura-vitrine\">\n                            <img class=\"imagem-vitrine\"");
            BeginWriteAttribute("src", " src=\"", 1585, "\"", 1649, 2);
            WriteAttributeValue("", 1591, "data:image/jpeg;base64,", 1591, 23, true);
#nullable restore
#line 44 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
WriteAttributeValue("", 1614, itensPedido.Produto.ImagemEmBase64, 1614, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Foto Produto\">\n                            <figcaption>\n                                ");
#nullable restore
#line 46 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
                           Write(itensPedido.Produto.NomeProduto);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\n                            </figcaption>\n                        </figure>\n                    </a>\n                </li>\n");
#nullable restore
#line 51 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\n    </div>\n");
#nullable restore
#line 54 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n<br />\n<br />\n\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\n    <link");
                BeginWriteAttribute("href", " href=\"", 1994, "\"", 2035, 1);
#nullable restore
#line 60 "E:\GITHUB\Projeto_Interdisciplinar\Projeto Interdisciplinar\Aplicação\Projeto_Interdisciplinar\Views\Carrinho\Index.cshtml"
WriteAttributeValue("", 2001, Url.Content("~/css/carrinho.css"), 2001, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1949701762ffe38a0deb5451a246712222fcb07312937", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n<script>\n    setInterval(function () {\n        // Comando a ser executado no intervalo de tempo\n        console.log(\"Comando executado a cada 5 segundos\");\n        Pesquisar();\n    }, 10000);\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ItensPedidoViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591