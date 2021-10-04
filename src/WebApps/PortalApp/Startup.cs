using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using PortalApp.Core;
using System;
using System.IdentityModel.Tokens.Jwt;

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
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddRazorPages();
            services.AddHttpContextAccessor();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = AuthenticationConsts.SignInScheme;
                options.DefaultChallengeScheme = AuthenticationConsts.OidcAuthenticationScheme;
            })
                .AddCookie(AuthenticationConsts.SignInScheme, options =>
                {
                    options.Cookie.Name = Configuration["IdentityServerConfig:CookieName"];
                    options.LoginPath = "/dang-nhap.html";
                })
                .AddOpenIdConnect(AuthenticationConsts.OidcAuthenticationScheme, options =>
                {
                    options.Authority = Configuration["IdentityServerConfig:IdentityServerUrl"];
                    options.ClientId = Configuration["IdentityServerConfig:ClientId"];
                    options.ClientSecret = Configuration["IdentityServerConfig:ClientSecret"];

                    options.ResponseType = "code";
                    options.RequireHttpsMetadata = false;
                    options.SaveTokens = true;
                });

            services.AddHttpClient("BackendApi", options =>
            {
                options.BaseAddress = new Uri(Configuration["BackendApiUrl"]);
            });

            services.RegisterCustomServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            IdentityModelEventSource.ShowPII = true;
        }
    }
}
