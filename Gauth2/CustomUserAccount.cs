using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Gauth2
{
    public class CustomUserAccount : RemoteUserAccount
    {
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
