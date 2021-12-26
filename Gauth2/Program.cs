using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gauth2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddOidcAuthentication<RemoteAuthenticationState, CustomUserAccount>(options =>
            {
                options.ProviderOptions.DefaultScopes.Add("email");
                builder.Configuration.Bind("Local", options.ProviderOptions);
            }).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, CustomAccountFactory>();

            await builder.Build().RunAsync();
        }


    }
}
