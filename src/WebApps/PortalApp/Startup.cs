using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using PortalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortalApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddRazorPages();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = AuthenticationConsts.SignInScheme;
                options.DefaultChallengeScheme = AuthenticationConsts.OidcAuthenticationScheme;
            })
                .AddCookie(AuthenticationConsts.SignInScheme, options =>
                {
                    options.Cookie.Name = Configuration["IdentityServerConfig:CookieName"];
                    options.LoginPath = "/login.html";
                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnValidatePrincipal = context =>
                        {
                            if (context.Properties.Items.ContainsKey(".Token.expires_at"))
                            {
                                var expire = DateTime.Parse(context.Properties.Items[".Token.expires_at"]);
                                if (expire < DateTime.Now)
                                {
                                    context.ShouldRenew = true;
                                    context.RejectPrincipal();
                                }
                            }
                            return Task.FromResult(0);
                        }
                    };
                })
                .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
                {
                    options.Authority = Configuration["IdentityServerConfig:IdentityServerUrl"];
                    options.ClientId = Configuration["IdentityServerConfig:ClientId"];
                    options.ClientSecret = Configuration["IdentityServerConfig:ClientSecret"];
                    options.ResponseType = "code";
                    options.RequireHttpsMetadata = false;
                    options.SaveTokens = true;

                    //Fix bypass SSL connection validate
                    HttpClientHandler handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                    options.BackchannelHttpHandler = handler;
                });
            services.AddHttpClient("BackendApi", options =>
            {
                options.BaseAddress = new Uri(Configuration["BackendApiUrl"]);
            })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            }
                });
            services.RegisterCustomServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IdentityModelEventSource.ShowPII = true;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
