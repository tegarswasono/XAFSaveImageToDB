using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Blazor.Services;
using DevExpress.Persistent.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XAFSaveImageToDB.Blazor.Server.Services;
using DevExpress.Xpo;
using XAFSaveImageToDB.Module.Helpers;
using DevExpress.Xpo.DB;

namespace XAFSaveImageToDB.Blazor.Server {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;

            string attachmentConnectionString = Configuration.GetConnectionString("AttachmentDB");

            string connectionString = attachmentConnectionString;
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
            var uow = new UnitOfWork();
            AttachmentHelper._uow = uow;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();
            services.AddSingleton<XpoDataStoreProviderAccessor>();
            services.AddScoped<CircuitHandler, CircuitHandlerProxy>();
            services.AddXaf<XAFSaveImageToDBBlazorApplication>(Configuration);
            services.AddXafSecurity(options => {
                options.RoleType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole);
                options.UserType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser);
                options.Events.OnSecurityStrategyCreated = securityStrategy => ((SecurityStrategy)securityStrategy).RegisterXPOAdapterProviders();
                options.SupportNavigationPermissionsForTypes = false;
            }).AddExternalAuthentication<HttpContextPrincipalProvider>()
            .AddAuthenticationStandard(options => {
                options.IsSupportChangePassword = true;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.LoginPath = "/LoginPage";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseXaf();
            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
