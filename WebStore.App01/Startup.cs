using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStore.App01.Services;
using WebStore.App01.Services.Interfaces;
using WebStore.DAL;
using WebStore.Domain.Entities;

namespace WebStore.App01
{

	public class Startup
	{

		public IConfiguration Configuration { get; }


		public Startup(
			IConfiguration configuration)
		{
			Configuration = configuration;
		}


		public void ConfigureServices(
			IServiceCollection services)
		{
			services.AddRazorPages()
				.AddRazorRuntimeCompilation();
			services.AddControllersWithViews()
				.AddRazorRuntimeCompilation();
			services.AddMvc()
				.AddNewtonsoftJson();

			services.AddSingleton<IDataService<Employee>, InMemoryEmployeesService>();
			services.AddSingleton<IDataService<Currency>, InMemoryCurrenciesService>();

			services.AddScoped<IProductService, SqlProductService>();

			services.AddDbContext<WebStoreContext>(
				options => options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<WebStoreContext>()
				.AddDefaultTokenProviders();

			//services.Configure<IdentityOptions>(options =>
			//{
			//	options.Password.RequireDigit = false;
			//	options.Password.RequiredLength = 5;
			//	options.Password.RequireLowercase = false;
			//	options.Password.RequireUppercase = false;
			//	options.Password.RequireNonAlphanumeric = false;
			//	options.Password.RequireLowercase = false;
			//	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
			//	options.Lockout.MaxFailedAccessAttempts = 10;
			//	options.Lockout.AllowedForNewUsers = true;
			//	options.User.RequireUniqueEmail = true;
			//});

			//services.ConfigureApplicationCookie(options =>
			//{
			//	options.Cookie.HttpOnly = true;
			//	//options.Cookie.Expiration = TimeSpan.FromDays(150);
			//	options.LoginPath = "/Account/Login";
			//	options.LogoutPath = "/Account/Logout";
			//	options.AccessDeniedPath = "/Account/AccessDenied";
			//	options.SlidingExpiration = true;
			//});
		}


		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}

	}

}
