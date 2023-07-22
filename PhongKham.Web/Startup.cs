using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhongKham.Core.Interface;
using PhongKham.Core.Interface.Base;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository;
using PhongKham.Infrastructure.Repository.Base;
using PhongKham.Infrastructure.UnitOfWork;
using PhongKham.Web.Interface;
using PhongKham.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhongKham.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            ConfigureAspnetRunServices(services);
            services.AddRazorPages();
        }

        private void ConfigureAspnetRunServices(IServiceCollection services)
        {
         

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddHttpContextAccessor();
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IRazorRenderService, RazorRenderService>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            //Lich Hen
            services.AddTransient<ILichHenRepository, LichHenRepository>();
            services.AddTransient<ILichHenService, LichHenService>();

            //Thuoc 
            services.AddTransient<IThuocRepository, ThuocRepository>();
            services.AddTransient<IThuocService, ThuocService>();

            //PhieuKhamBenh
            services.AddTransient<IPhieuKhamBenhRepository, PhieuKhamBenhRepository>();
            services.AddTransient<IPhieuKhamBenhService, PhieuKhamBenhService>();


            //ToaThuoc
            services.AddTransient<IToaThuocRepository, ToaThuocRepository>();
            services.AddTransient<IToaThuocService, ToaThuocService>();


            //ChiTietToaThuoc
            services.AddTransient<IChiTietToaThuocRepository, ChiTietToaThuocRepository>();
            services.AddTransient<IChiTietToaThuocService, ChiTietToaThuocService>();

            //HoaDon
            services.AddTransient<IHoaDonRepository, HoaDonRepository>();
            services.AddTransient<IHoaDonService, HoaDonService>();


            //Benh
            services.AddTransient<IBenhRepository, BenhRepository>();
            services.AddTransient<IBenhService, BenhService>();

            //UnitOfWork service
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //Session for ToaThuoc
            services.AddSession();
            services.AddMemoryCache();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database

            services.AddDbContext<PhongKhamDbContext>(options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("PhongKham")));

            //// use real database
            //services.AddDbContext<AspnetRunContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("AspnetRunConnection"), x => x.MigrationsAssembly("AspnetRun.Web")));
        }
    }
}
