using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsInteropDemo.Pages
{
    public class JsGridDemoModel : BlazorComponent
    {
        public static void ShowGrid()
        {
            JSRuntime.Current.InvokeAsync<bool>("showJsGrid");
        }
    }
}