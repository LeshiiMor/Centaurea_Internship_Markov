using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.IdentityServer.Data;
using TicketShop.IdentityServer.Data.Models;
using TicketShop.IdentityServer.Services;

namespace TicketShop.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddPolicy("DefaultPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            services.AddDbContext<ContextDb>(options => options.UseMySql(
               _configuration.GetConnectionString("DefaultConnection"),
               new MySqlServerVersion(new Version(8, 0, 21))
           ))
               .AddIdentity<User,IdentityRole<int>>(config=> 
               {
                   config.Password.RequireDigit = false;
                   config.Password.RequireLowercase = false;
                   config.Password.RequireNonAlphanumeric = false;
                   config.Password.RequireUppercase = false;
                   config.Password.RequiredLength = 4;
               })
               .AddEntityFrameworkStores<ContextDb>();

            services.ConfigureApplicationCookie(config=> 
            {
                config.LoginPath = "/auth/login";
                config.LogoutPath = "/auth/logout";
                config.Cookie.Name = "IdentityServer.Cookies";
            });

            services.AddIdentityServer()
                .AddAspNetIdentity<User>()
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddInMemoryClients(Configuration.GetClients())
                .AddInMemoryApiScopes(Configuration.GetApiScopes())
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();


            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("DefaultPolicy");

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
