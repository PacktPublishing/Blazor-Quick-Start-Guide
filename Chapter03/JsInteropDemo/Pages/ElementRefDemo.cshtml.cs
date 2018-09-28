using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.JSInterop;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JsInteropDemo.Pages
{
    public static class ElementRefDemoExtension
    {
        public static Task GetValue(this ElementRef elementRef)
        {
            return JSRuntime.Current.InvokeAsync<object>("showValue", elementRef);
        }
    }

    public class ElementRefDemoModel : BlazorComponent
    {
        public ElementRef inputRef;
        public void getInputValue()
        {
            inputRef.GetValue();
        }
    }
}