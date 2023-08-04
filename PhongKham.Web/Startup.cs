using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhongKham.Core.Entities;
using PhongKham.Core.Interface;
using PhongKham.Core.Interface.Base;
using PhongKham.Infrastructure.Data;
using PhongKham.Infrastructure.Repository;
using PhongKham.Infrastructure.Repository.Base;
using PhongKham.Infrastructure.UnitOfWork;
using PhongKham.Web.Initialize.SeedData;
using PhongKham.Web.Initialize.SetupIdentity;
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
            ConfigureIdentiy(services);
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
        private void ConfigureIdentiy(IServiceCollection services)
        {
            services.AddIdentity<UserAccount, IdentityRole>().AddEntityFrameworkStores<PhongKhamDbContext>().AddDefaultTokenProviders();

            //Cookie
            services.ConfigureApplicationCookie(options => {
                // options.Cookie.HttpOnly = true;
                // options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = $"/login/";
                options.LogoutPath = $"/logout/";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            services.Configure<IdentityOptions>(options => {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại




            });
            
            services.AddHostedService<SetupIdentityDataSeeder>();
            services.AddTransient<SeedInitAccount>();
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
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

    }
}
