//=================================================================================================================
// Projekt:     VUT, FIT, ITU, celosemestralni projekt
// Datum:       28. 11. 2021
// Autor:       David Mihola
// Kontakt:     xmihol00@stud.fit.vutbr.cz
//=================================================================================================================

using itu.BL.Facades;
using itu.BL.Profiles;
using itu.DAL;
using itu.DAL.Repositories;
using itu.WEB.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itu.WEB
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
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            
            services.AddSignalR();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Signin";
                        options.LogoutPath = "/Account/Forbidden/";
                    });

            services.AddDbContext<ItuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DB")));

            services.AddAutoMapper(typeof(UserProfiles), typeof(TaskProfiles), typeof(FileProfiles), typeof(AgendaProfiles));

            services.AddScoped<UserRepository>();
            services.AddScoped<AgendaRepository>();
            services.AddScoped<TaskRepository>();
            services.AddScoped<FileRepository>();
            services.AddScoped<FileDataRepository>();
            services.AddScoped<WorkflowRepository>();
            services.AddScoped<AgendaRoleRepository>();
            services.AddScoped<ModelWorkflowRepository>();
            services.AddScoped<AgendaModelRepository>();

            services.AddScoped<BaseFacade>();
            services.AddScoped<UserFacade>();
            services.AddScoped<TaskFacade>();
            services.AddScoped<FileFacade>();
            services.AddScoped<AgendaFacade>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                    pattern: "{controller=Task}/{action=Overview}/{id?}");
                endpoints.MapHub<TaskNotificationHub>("/hub");
            });

            using (var serviceScope = app.ApplicationServices
                                         .GetRequiredService<IServiceScopeFactory>()
                                         .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ItuDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
