using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsInteropDemo.Pages
{
    public class CallCSMethodModel : BlazorComponent
    {
        protected static string message { get; set; }
        protected void invokeJSMethod()
        {
            JSRuntime.Current.InvokeAsync<bool>("callCSFunction");
        }

        [JSInvokable]
        public static void CSCallBackMethodAsync()
        {
            message = "C# Method invoked";
        }
    }
}