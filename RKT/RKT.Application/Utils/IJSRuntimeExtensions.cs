using Microsoft.JSInterop;

namespace RKT.Application.Utils
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("toastrSuccess", message);
        }

        public static async Task ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("toastrError", message);
        }
    }
}
