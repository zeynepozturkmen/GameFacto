using GameFacto.Core.Entities;
using GameFacto.Data.DbContexts;
using GameFacto.Service.IService;
using GameFacto.Service.Service;
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

namespace GameFacto.UI
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
            var connectionString = Configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<GameFactoDbContext>(options => options.UseSqlServer(connectionString, optionsBuilder =>
                optionsBuilder.MigrationsAssembly("GameFacto.Data")), ServiceLifetime.Scoped
            );

            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICagetoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();


            services.AddIdentity<User, AppRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
                cfg.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
                cfg.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
                cfg.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
                cfg.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.
                cfg.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<GameFactoDbContext>().AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                //Javascript document diyerek cooki'deki(giri� yapan kullan�c�n�n bilgileri vs) ulasilmas�n� engelliyor.
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "Test";
                //Sub domain'de dahil olmak �zere di�er sitelerin cookie'ye eri�imini kapat�yor
                options.Cookie.SameSite = SameSiteMode.Strict;
                //Http ya da https �zerinden �al���yor
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                //Yetki yoksa;yetkiniz yok sayfas� d�n�yor
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.ExpireTimeSpan = TimeSpan.FromDays(14);
                options.SlidingExpiration = true;
            });

            services.AddControllersWithViews();

            //sayfayi yenileyince yenilikleri algilamasi icin
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddSession();
            services.AddHttpContextAccessor();
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
            }

            app.UseHttpsRedirection();

            app.UseSession();


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
