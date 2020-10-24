using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
		}


		public void Configure(
			IApplicationBuilder app,
			IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}

	}

}
