using CoreProject.Data;
using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using CoreProject.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace CoreProject
{
    public class Startup
    {
        private IConfigurationRoot _configString;
        public Startup(IHostEnvironment hostingEnvironment)
        {
            _configString = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("db_settings.json").Build();
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options =>
            {
                options.UseSqlServer(_configString.GetConnectionString("DefaultConnection"));
            });
            services.AddRazorPages();
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDistributedMemoryCache();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Пользовательские
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });

            });
            //
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", (int id, IAllCars allCars) => GetCar(id, allCars));
                endpoints.MapRazorPages();
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObjects.Initial(content);
            }
            app.Run(async (context) =>
            {
                if (context.Session.Keys.Contains("currentLogin") && context.Session.Keys.Contains("currentPassword"))
                    await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
                else
                {
                    context.Session.SetString("currentLogin", "Ivan");
                    context.Session.SetString("currentPassword", "ivan123");
                }
            });
        }
    }
}
