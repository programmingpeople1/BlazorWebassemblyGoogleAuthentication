using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace Gauth2
{
    public class CustomUserAccount : RemoteUserAccount
    {
        [JsonPropertyName("azp")]
        public string azp { get; set; }      
    }
}
