using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestNugetCore5
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
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(item => item.LoginPath = new PathString("/account/login"))

    // You must first create an app with Microsoft Account and add its ID and Secret to your user-secrets.
    // https://azure.microsoft.com/en-us/documentation/articles/active-directory-v2-app-registration/

    // Way 1
    .AddOAuth("Microsoft-AccessToken", "Microsoft AccessToken only", option =>
    {
        option.ClientId = Configuration["Authentication:Microsoft:clientid"];
        option.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
        option.CallbackPath = new PathString("/signin-microsoft-token");
        option.AuthorizationEndpoint = MicrosoftAccountDefaults.AuthorizationEndpoint;
        option.TokenEndpoint = MicrosoftAccountDefaults.TokenEndpoint;
        option.Scope.Add("https://graph.microsoft.com/user.read");
        option.SaveTokens = true;
        option.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
        option.ClaimActions.MapJsonKey(ClaimTypes.Name, "displayName");
        option.ClaimActions.MapJsonKey(ClaimTypes.GivenName, "givenName");
        option.ClaimActions.MapJsonKey(ClaimTypes.Surname, "surname");
        option.ClaimActions.MapCustomJson(ClaimTypes.Email,
            user => user.GetString("mail") ?? user.GetString("userPrincipalName"));
    })

    // Way 2
    .AddMicrosoftAccount(option =>
    {
        option.ClientId = Configuration["Authentication:Microsoft:clientid"];
        option.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
        option.SaveTokens = true;
    });
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
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
