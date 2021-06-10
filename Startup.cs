using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicApp.IdentityData;
using MusicApp.MusicData;

namespace MusicApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IdentityDataSeeder>();
            services.AddHostedService<SetupIdentityDataSeeder>();
            services.AddScoped<MusicDataSeeder>();
            services.AddHostedService<SetupMusicDataSeeder>();
            services.AddMediatR(typeof(Startup).Assembly);

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), options =>
                    {
                        options.MigrationsHistoryTable("__IdentityMigrationsHistory", "identity");
                    }));

            services.AddDbContext<MusicDataDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), options =>
                    {
                        options.MigrationsHistoryTable("__IdentityMigrationsHistory", "music");
                    }));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, IdentityDbContext>(options =>
                {
                    options.IdentityResources.Add(new IdentityResource(
                            name: "roles",
                            displayName: "Roles",
                            userClaims: new List<string> { "role" })
                    { Required = true });
                    options.Clients[0].AllowedScopes.Add("roles");
                });

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Path.Value.StartsWith("/api"))
                    {
                        context.Response.Headers["Location"] = context.RedirectUri;
                        context.Response.StatusCode = 401;
                    }
                    else
                    {
                        context.Response.Redirect(context.RedirectUri);
                    }
                    return Task.CompletedTask;
                };
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapGet("/Identity/Account/Register", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/StatusMessage", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ConfirmEmailChange", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ForgotPasswordConfirmation", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/LoginWith2fa", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/RegisterConfirmation", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ResetPasswordConfirmation", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/AccessDenied", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ExternalLogin", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Lockout", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/LoginWithRecoveryCode", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ConfirmEmail", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ForgotPassword", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ResetPassword", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/ResendEmailConfirmation", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));

                endpoints.MapGet("/Identity/Account/Manage/SetPassword", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/Index", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/EnableAuthenticator", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/Disable2fa", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/StatusMessage", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/TwoFactorAuthentication", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/ResetAuthenticator", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/GenerateRecoveryCodes", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/Email", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/DeletePersonalData", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/ManageNav", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/ShowRecoveryCodes", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/PersonalData", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/ExternalLogins", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/DownloadPersonalData", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/ChangePassword", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
                endpoints.MapGet("/Identity/Account/Manage/Layout", context => Task.Factory.StartNew(() => context.Response.StatusCode = 404));
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
