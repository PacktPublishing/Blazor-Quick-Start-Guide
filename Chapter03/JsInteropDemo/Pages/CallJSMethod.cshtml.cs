using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsInteropDemo.Pages
{
    public class CallJSMethodModel : BlazorComponent
    {
        protected string message { get; set; }
        protected void CallJSMethod()
        {
            JSRuntime.Current.InvokeAsync<bool>("showAlertBox");
        }
        protected void CallJSMethodWithParams()
        {
            JSRuntime.Current.InvokeAsync<bool>("showPrompt", message);
        }
    }
}