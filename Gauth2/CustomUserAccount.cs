using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Gauth2
{
    public class CustomUserAccount : RemoteUserAccount
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("picture")]
        public string Picture { get; set; }
    }
}
