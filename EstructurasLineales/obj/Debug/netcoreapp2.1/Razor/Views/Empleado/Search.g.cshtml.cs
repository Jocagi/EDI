#pragma checksum "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7210c6a9219b9b8be211867465304039d05890a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Empleado_Search), @"mvc.1.0.view", @"/Views/Empleado/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Empleado/Search.cshtml", typeof(AspNetCore.Views_Empleado_Search))]
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
#line 1 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\_ViewImports.cshtml"
using EstructurasLineales;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\_ViewImports.cshtml"
using EstructurasLineales.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7210c6a9219b9b8be211867465304039d05890a8", @"/Views/Empleado/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"993833774da09366e49ab1f9af21a824dc149f4f", @"/Views/_ViewImports.cshtml")]
    public class Views_Empleado_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EstructurasLineales.Models.Empleado>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
  
    ViewBag.Title = "Buscador";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(87, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(146, 21, true);
            WriteLiteral("\r\n<h2>Buscar</h2>\r\n\r\n");
            EndContext();
#line 10 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(197, 36, true);
            WriteLiteral("    <p>\r\n        Realizar Busqueda: ");
            EndContext();
            BeginContext(234, 22, false);
#line 13 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
                      Write(Html.TextBox("codigo"));

#line default
#line hidden
            EndContext();
            BeginContext(256, 328, true);
            WriteLiteral(@"
        <input type=""submit"" value=""Buscar"" />

        <br> Escriba el nombre del empleado, su codigo o la cantidad de horas trabajadas...
        <br> Si desea ver a los empleados que estan en la oficina en ese momento escriba ""Oficina"" y si desea ver quienes no es estan en la oficina escriba ""!Oficina""...

    </p>
");
            EndContext();
#line 20 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"


}

#line default
#line hidden
            BeginContext(591, 450, true);
            WriteLiteral(@"<table class=""table"">
    <tr>
        <th>
            Nombre
        </th>
        <th>
            Codigo
        </th>
        <th>
            Hora de Entrada
        </th>
        <th>
            Hora de Salida
        </th>
        <th>
            Esta en Oficina
        </th>
        <th>
            Horas Trabajadas
        </th>
        <th>
            Salario (Q.)
        </th>
        <th></th>
    </tr>

");
            EndContext();
#line 49 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(1082, 36, true);
            WriteLiteral("    <tr>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1119, 65, false);
#line 53 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.ActionLink(item.nombre, "Details", new { id = item.codigo }));

#line default
#line hidden
            EndContext();
            BeginContext(1184, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1228, 41, false);
#line 56 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.DisplayFor(modelItem => item.codigo));

#line default
#line hidden
            EndContext();
            BeginContext(1269, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1313, 46, false);
#line 59 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.DisplayFor(modelItem => item.horaEntrada));

#line default
#line hidden
            EndContext();
            BeginContext(1359, 3, true);
            WriteLiteral(" : ");
            EndContext();
            BeginContext(1363, 48, false);
#line 59 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
                                                         Write(Html.DisplayFor(modelItem => item.minutoEntrada));

#line default
#line hidden
            EndContext();
            BeginContext(1411, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1455, 45, false);
#line 62 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.DisplayFor(modelItem => item.horaSalida));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1544, 39, false);
#line 65 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.DisplayFor(modelItem => item.disp));

#line default
#line hidden
            EndContext();
            BeginContext(1583, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1627, 40, false);
#line 68 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.DisplayFor(modelItem => item.horas));

#line default
#line hidden
            EndContext();
            BeginContext(1667, 43, true);
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
            EndContext();
            BeginContext(1711, 42, false);
#line 71 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
       Write(Html.DisplayFor(modelItem => item.salario));

#line default
#line hidden
            EndContext();
            BeginContext(1753, 28, true);
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
            EndContext();
#line 74 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
    }

#line default
#line hidden
            BeginContext(1788, 113, true);
            WriteLiteral("\r\n</table>\r\n\r\n\r\n<h2>Simulacion de salidas y regresos</h2>\r\n\r\n<input type=\"button\"\r\n       value=\"Salida a visita\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n       onclick=\"", 1901, "\"", 1970, 4);
            WriteAttributeValue("", 1919, "location.href=", 1919, 14, true);
            WriteAttributeValue(" ", 1933, "\'", 1934, 2, true);
#line 83 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
WriteAttributeValue("", 1935, Url.Action("Salida", "Empleado" ), 1935, 34, false);

#line default
#line hidden
            WriteAttributeValue("", 1969, "\'", 1969, 1, true);
            EndWriteAttribute();
            BeginContext(1971, 66, true);
            WriteLiteral(" %> \r\n<br>\r\n<input type=\"button\"\r\n       value=\"Regreso a oficina\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n       onclick=\"", 2037, "\"", 2107, 4);
            WriteAttributeValue("", 2055, "location.href=", 2055, 14, true);
            WriteAttributeValue(" ", 2069, "\'", 2070, 2, true);
#line 87 "C:\Users\user\Desktop\EstructurasLineales\EstructurasLineales\Views\Empleado\Search.cshtml"
WriteAttributeValue("", 2071, Url.Action("Regreso", "Empleado" ), 2071, 35, false);

#line default
#line hidden
            WriteAttributeValue("", 2106, "\'", 2106, 1, true);
            EndWriteAttribute();
            BeginContext(2108, 8, true);
            WriteLiteral(" %> \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EstructurasLineales.Models.Empleado>> Html { get; private set; }
    }
}
#pragma warning restore 1591
