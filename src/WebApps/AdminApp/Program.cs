using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Blazored.SessionStorage;
using AdminApp.Services.Interfaces;
using AdminApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using AdminApp.Core.Authentication;

namespace AdminApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["BackendApiUrl"])
            });
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}
