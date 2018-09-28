using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsInteropDemo.Pages
{
    public class HelloWorld
    {
        [JSInvokable]
        public string showMessege() => $"Hello World";
    }
    public class InvokeInstanceMethodModel : BlazorComponent
    {
        public static Task DisplayMessage()
        {
            return JSRuntime.Current.InvokeAsync<object>(
                "callInstanceMethod",
                new DotNetObjectRef(new HelloWorld()));
        }
    }
}
