#pragma checksum "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df9e823f706ad2022fac191577f7d2a24dbced33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Content_Index), @"mvc.1.0.view", @"/Views/Content/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Content/Index.cshtml", typeof(AspNetCore.Views_Content_Index))]
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
#line 1 "D:\vsproj\Sample02\Sample02\Views\_ViewImports.cshtml"
using Sample02;

#line default
#line hidden
#line 2 "D:\vsproj\Sample02\Sample02\Views\_ViewImports.cshtml"
using Sample02.Models;

#line default
#line hidden
#line 2 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
using Humanizer;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df9e823f706ad2022fac191577f7d2a24dbced33", @"/Views/Content/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"964a072517940dfe9aaf5c4ccbcdccd70374a317", @"/Views/_ViewImports.cshtml")]
    public class Views_Content_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
  
    ViewData["Title"] = "内容列表";

#line default
#line hidden
            BeginContext(84, 79, true);
            WriteLiteral("\r\n<div class=\"panel panel-default todo-panel\">\r\n    <div class=\"panel-heading\">");
            EndContext();
            BeginContext(164, 17, false);
#line 8 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(181, 343, true);
            WriteLiteral(@"</div>

    <table class=""table table-hover"">
        <thead>
            <tr>
                <td> <input type=""checkbox"" class=""done-checkbox""></td>
                <td>序号</td>
                <td>标题</td>
                <td>内容</td>
                <td>作者</td>
                <td>添加时间</td>
            </tr>
        </thead>

");
            EndContext();
#line 22 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
         foreach (var item in Model.ContentList)
        {

#line default
#line hidden
            BeginContext(585, 130, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                <input type=\"checkbox\" class=\"done-checkbox\">\r\n            </td>\r\n            <td>");
            EndContext();
            BeginContext(716, 7, false);
#line 28 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
           Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(723, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(747, 10, false);
#line 29 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
           Write(item.title);

#line default
#line hidden
            EndContext();
            BeginContext(757, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(781, 12, false);
#line 30 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
           Write(item.content);

#line default
#line hidden
            EndContext();
            BeginContext(793, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(817, 11, false);
#line 31 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
           Write(item.author);

#line default
#line hidden
            EndContext();
            BeginContext(828, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(852, 24, false);
#line 32 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
           Write(item.add_time.Humanize());

#line default
#line hidden
            EndContext();
            BeginContext(876, 24, true);
            WriteLiteral("</td>\r\n\r\n        </tr>\r\n");
            EndContext();
#line 35 "D:\vsproj\Sample02\Sample02\Views\Content\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(911, 24, true);
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
