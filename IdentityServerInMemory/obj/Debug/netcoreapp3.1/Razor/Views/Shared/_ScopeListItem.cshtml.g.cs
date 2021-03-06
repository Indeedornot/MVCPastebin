#pragma checksum "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af86760e93a2daaa4f176046aa8d591f5e003401"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ScopeListItem), @"mvc.1.0.view", @"/Views/Shared/_ScopeListItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af86760e93a2daaa4f176046aa8d591f5e003401", @"/Views/Shared/_ScopeListItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b35857dd199098649926cf8d40cf1622e149676b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__ScopeListItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdentityServerInMemory.Controllers.Consent.ScopeViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<li class=\"list-group-item\">\n    <label>\n        <input class=\"consent-scopecheck\"\n               type=\"checkbox\"\n               name=\"ScopesConsented\"");
            BeginWriteAttribute("id", "\n               id=\"", 217, "\"", 256, 2);
            WriteAttributeValue("", 237, "scopes_", 237, 7, true);
#nullable restore
#line (8,27)-(8,39) 29 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 244, Model.Value, 244, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", "\n               value=\"", 257, "\"", 292, 1);
#nullable restore
#line (9,23)-(9,35) 29 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 280, Model.Value, 280, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("checked", "\n               checked=\"", 293, "\"", 332, 1);
#nullable restore
#line (10,25)-(10,39) 29 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 318, Model.Checked, 318, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("disabled", "\n               disabled=\"", 333, "\"", 374, 1);
#nullable restore
#line (11,26)-(11,41) 29 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 359, Model.Required, 359, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n");
#nullable restore
#line 12 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
         if (Model.Required)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <input type=\"hidden\"\n                   name=\"ScopesConsented\"");
            BeginWriteAttribute("value", "\n                   value=\"", 492, "\"", 531, 1);
#nullable restore
#line (16,27)-(16,39) 29 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 519, Model.Value, 519, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n");
#nullable restore
#line 17 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <strong>");
#nullable restore
#line (18,18)-(18,35) 6 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
Write(Model.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\n");
#nullable restore
#line 19 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
         if (Model.Emphasize)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"glyphicon glyphicon-exclamation-sign\"></span>\n");
#nullable restore
#line 22 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </label>\n");
#nullable restore
#line 24 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
     if (Model.Required)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span><em>(required)</em></span>\n");
#nullable restore
#line 27 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
     if (Model.Description != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"consent-description\">\n            <label");
            BeginWriteAttribute("for", " for=\"", 904, "\"", 929, 2);
            WriteAttributeValue("", 910, "scopes_", 910, 7, true);
#nullable restore
#line (31,32)-(31,44) 29 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
WriteAttributeValue("", 917, Model.Value, 917, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line (31,47)-(31,64) 6 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\n        </div>\n");
#nullable restore
#line 33 "C:\Users\Indeed\Desktop\Repositories\PastebinMVC\IdentityServerInMemory\Views\Shared\_ScopeListItem.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdentityServerInMemory.Controllers.Consent.ScopeViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
